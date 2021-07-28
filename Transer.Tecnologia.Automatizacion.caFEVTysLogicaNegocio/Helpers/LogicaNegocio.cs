using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura;
using Transer.Tecnologia.Automatizacion.CallExecute;
using Transer.Tecnologia.Automatizacion.Correo;
using Transer.Tecnologia.Automatizacion.EncodingFE;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.HttpsSendXmlDocument;
using Transer.Tecnologia.Automatizacion.Infrastructure;
namespace Transer.Tecnologia.Automatizacion.caFEVTysLogicaNegocio
{
    public partial class LogicaNegocio
    {
        /*VERSION PRODUCCION*/
        private void procesarFactura(LogReporteDian infoFactura)
        {
            //console.Ih("",false);
            console.Ih("=> Procesar factura : " + infoFactura.LODI_LLAVE_V2 + " Fecha : " + infoFactura.LODI_FECREGISTRO_DT,false);            
            validarDirectorio(infoFactura.LODI_LLAVE_V2);
            console.Ih("    * Generando informacion Dian");
            int recordProcessed = generarInfoDian(infoFactura.LODI_LLAVE_V2, infoFactura.LODI_OFICINA_NB, infoFactura.LODI_TRANSACCION_NB);
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            console.Ih("    * LeerInformacionDian       ");
            ICInformacionDian = LeerInformacionDian(infoFactura.LODI_LLAVE_V2);
            if (ICInformacionDian.Count > 0)
            {
                foreach (InformacionDian item in ICInformacionDian)
                {
                    HttpsWebRequestsFunction httpwebrequestFunction = new HttpsWebRequestsFunction();
                    httpwebrequestFunction._FacturaXml = item.INDI_XMLENV_CB;
                    httpwebrequestFunction._Numdoc = infoFactura.LODI_LLAVE_V2;
                    console.Ih("    * Procesando Anexos         ");
                    if (procesarAnexos(infoFactura))
                    {
                        console.Ih("    * comprimirAdjuntos         ");
                        long sizeAnexo = comprimirAdjuntos(infoFactura.LODI_LLAVE_V2, item);
                        if (sizeAnexo <= 2300000)
                        {
                            console.Ih("    * comprimirFactura          ");
                            httpwebrequestFunction._FileName = infoFactura.LODI_LLAVE_V2 + ".zip";
                            if (comprimirFactura(infoFactura.LODI_LLAVE_V2, item.INDI_XMLENV_CB))
                            {
                                httpwebrequestFunction._FileData = GetdataXmlAnexos(infoFactura.LODI_LLAVE_V2);
                            }
                        }
                        else
                        {
                            console.Ih("    * Los Anexos sobrepasan la capacidad. Se envia sin Anexos");
                            httpwebrequestFunction._FileName = infoFactura.LODI_LLAVE_V2 + ".xml";
                            using (StreamWriter writer = new StreamWriter("c:\\transer\\ws\\facturacion\\" + infoFactura.LODI_LLAVE_V2 + "\\anexos\\" + infoFactura.LODI_LLAVE_V2 + ".xml"))
                            {
                                writer.WriteLine(item.INDI_XMLENV_CB);
                            }
                            EncodingFacturacionElectronica encoding = new EncodingFacturacionElectronica();
                            httpwebrequestFunction._FileData = encoding.Base64Encode(item.INDI_XMLENV_CB);
                        }
                    }
                    else
                    {
                        console.Ih("    * La Factura no tiene Anexos");
                        httpwebrequestFunction._FileName = infoFactura.LODI_LLAVE_V2 + ".xml";
                        using (StreamWriter writer = new StreamWriter("c:\\transer\\ws\\facturacion\\" + infoFactura.LODI_LLAVE_V2 + "\\anexos\\" + infoFactura.LODI_LLAVE_V2 + ".xml"))
                        {
                            writer.WriteLine(item.INDI_XMLENV_CB);
                        }
                        EncodingFacturacionElectronica encoding = new EncodingFacturacionElectronica();
                        httpwebrequestFunction._FileData = encoding.Base64Encode(item.INDI_XMLENV_CB);

                    }
                    console.Ih("=> Maquetando Paquete Soap      ");
                    httpwebrequestFunction = MaquetarPaqueteSoap(httpwebrequestFunction);
                    console.Ih("=> Enviando Factura             ");
                    httpwebrequestFunction = EnviarFactura(httpwebrequestFunction);
                    console.Ih("=> Procesando Respuesta         ");
                    string statusFactura = procesarNewXMLRecibido(httpwebrequestFunction, infoFactura);
                    SendEmailFacturaClient sendEmailFacturaClient = new SendEmailFacturaClient(Usuario, Password, UsuEmail, PassEmail, Ambiente);
                    var sendMailClient = sendEmailFacturaClient.SendMailClients(item);
                }
            }
            else
            {
                //"No hay informacion asociada a la factura....
            }
        }
        private void consultarEstadoFactura(LogReporteDian infoFactura)
        {
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            ICInformacionDian = LeerInformacionDian(infoFactura.LODI_LLAVE_V2);
        }
        private void LoadICLogReporteDian()
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LODI_ESTADO" };
            _vParametros = new object[1] { "P" };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getLogReporteDian", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        ICLogReporteDian.Add(addLogReporteDian(item));
                    }
                }
                else
                {
                    console.Ih("NO HAY REGISTROS PARA PROCESAR....");
                    System.Threading.Thread.Sleep(6000);
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
        }
        private LogReporteDian addLogReporteDian(DataRow item)
        {
            LogReporteDian logReporteDian = new LogReporteDian();
            logReporteDian.LODI_SECUENCIA_NB = double.Parse(item["LODI_SECUENCIA_NB"].ToString());
            logReporteDian.LODI_OFICINA_NB = int.Parse(item["LODI_OFICINA_NB"].ToString());
            logReporteDian.LODI_TRANSACCION_NB = int.Parse(item["LODI_TRANSACCION_NB"].ToString());
            logReporteDian.LODI_LLAVE_V2 = item["LODI_LLAVE_V2"].ToString();
            logReporteDian.LODI_FECREGISTRO_DT = DateTime.Parse(item["LODI_FECREGISTRO_DT"].ToString());
            logReporteDian.LODI_ESTADO_V2 = item["LODI_ESTADO_V2"].ToString();
            try
            {
                logReporteDian.LODI_CAMPO1_NB = double.Parse(item["LODI_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {

                logReporteDian.LODI_CAMPO1_NB = 0;
                //ManejoError(ex, "logReporteDian.LODI_CAMPO1_NB = double.Parse(item[\"LODI_CAMPO1_NB\"].ToString());");
            }

            logReporteDian.LODI_CAMPO2_V2 = item["LODI_CAMPO2_V2"].ToString();
            try
            {
                logReporteDian.LODI_CAMPO3_DT = DateTime.Parse(item["LODI_CAMPO3_DT"].ToString());
            }
            catch (Exception ex)
            {
                logReporteDian.LODI_CAMPO3_DT = DateTime.UtcNow;
                //ManejoError(ex, "logReporteDian.LODI_CAMPO3_DT = DateTime.Parse(item[\"LODI_CAMPO3_DT\"].ToString());");
            }

            logReporteDian.LODI_ESTADODIAN_V2 = item["LODI_ESTADODIAN_V2"].ToString();

            return logReporteDian;
        }
        private ICollection<InformacionDian> LeerInformacionDian(string lODI_LLAVE_V2)
        {
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":INDI_NUMDOC" };
            _vParametros = new object[1] { lODI_LLAVE_V2 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getInformacionDian", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            ICInformacionDian.Add(addInformacionDian(item));
                        }
                        catch (Exception exx)
                        {

                            ManejoError(exx, "ICInformacionDian.Add(addInformacionDian(item));");
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return ICInformacionDian;
        }
        private InformacionDian addInformacionDian(DataRow item)
        {
            InformacionDian informacionDian = new InformacionDian();
            informacionDian.INDI_NUMDOC_V2 = item["INDI_NUMDOC_V2"].ToString();
            informacionDian.INDI_OFICDOC_NB = int.Parse(item["INDI_OFICDOC_NB"].ToString());
            informacionDian.INDI_TIPODOC_V2 = item["INDI_TIPODOC_V2"].ToString();
            informacionDian.INDI_EMAIL_V2 = item["INDI_EMAIL_V2"].ToString();
            informacionDian.INDI_XMLENV_CB = validarPuntoyComa(item["INDI_XMLENV_CB"].ToString());
            informacionDian.INDI_CUFEDIAN_V2 = item["INDI_CUFEDIAN_V2"].ToString();
            informacionDian.INDI_IDCARVAJAL_V2 = item["INDI_IDCARVAJAL_V2"].ToString();
            informacionDian.INDI_XMLREC_BL = InitializateBl();
            informacionDian.INDI_REPGRAFICA_BL = InitializateBl();
            informacionDian.INDI_XMLLEGAL_CB = item["INDI_XMLLEGAL_CB"].ToString();
            informacionDian.INDI_FECCREA_TS = DateTime.Parse(item["INDI_FECCREA_TS"].ToString());
            informacionDian.INDI_FECESTADO_TS = DateTime.Parse(item["INDI_FECCREA_TS"].ToString());
            informacionDian.INDI_VALIDACION_CL = item["INDI_VALIDACION_CL"].ToString();
            try
            {
                informacionDian.INDI_CLIENTE_NB = int.Parse(item["INDI_CLIENTE_NB"].ToString());
            }
            catch (Exception ex)
            {
                informacionDian.INDI_CLIENTE_NB = int.MinValue;
            }
            try
            {                
                    informacionDian.INDI_NOMCLIENTE_V2 = item["INDI_NOMCLIENTE_V2"].ToString();
            }
            catch (Exception ex)
            {
                informacionDian.INDI_NOMCLIENTE_V2 = string.Empty;
            }
            return informacionDian;
        }
        private string validarPuntoyComa(string XmlOriginal)
        {
            string XmlModificado = string.Empty;
            if (XmlOriginal.Contains(","))
            {
                XmlModificado = XmlOriginal.Replace(",", ".");
            }
            else
            {
                XmlModificado = XmlOriginal;
            }
            return XmlModificado;
            
        }
        private byte[] InitializateBl()
        {
            return new byte[1];
        }
        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            console.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
        }
        private void validarDirectorio(string factura)
        {
            string ruta = @"c:\transer\ws\facturacion\" + factura;
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
            string anexos = ruta + "\\anexos";
            if (!Directory.Exists(anexos))
                Directory.CreateDirectory(anexos);
        }
        private int generarInfoDian(string factura, int oficina, int transaccion)
        {
            int recordProcessed = int.MinValue;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[4] { ":factura", ":oficina", ":tipodoc", ":tipotransaccion" };
            switch (transaccion)
            {
                case 1:
                    {
                        try
                        {
                            _vParametros = new object[4] { factura, oficina, "FC", "I" };
                            Factory data = new Factory(Usuario, Password, Ambiente);
                            if (oficina==34)
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianFacturaOperativo", _nParametros, _vParametros);
                            }
                            else
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianFactura", _nParametros, _vParametros);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            ManejoError(ex, "var recordProcessed = data.executeCommand(\"pdbInfoDian\", _nParametros, _vParametros);");
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            _vParametros = new object[4] { factura, oficina, "NC", "I" };
                            Factory data = new Factory(Usuario, Password, Ambiente);

                            recordProcessed = (oficina == 34) ? data.executeCommand("pdbInfoDianNotaOperativo", _nParametros, _vParametros) : data.executeCommand("pdbInfoDianNota", _nParametros, _vParametros);
                            
                            /*if (oficina == 34)
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianNotaOperativo", _nParametros, _vParametros);
                            }
                            else
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianNota", _nParametros, _vParametros);
                            }*/
                        }
                        catch (Exception ex)
                        {
                            ManejoError(ex, "var recordProcessed = data.executeCommand(\"pdbInfoDian\", _nParametros, _vParametros);");
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            _vParametros = new object[4] { factura, oficina, "ND", "I" };
                            Factory data = new Factory(Usuario, Password, Ambiente);
                            recordProcessed = (oficina == 34) ? data.executeCommand("pdbInfoDianNotaOperativo", _nParametros, _vParametros) : data.executeCommand("pdbInfoDianNota", _nParametros, _vParametros);
                            /*if (oficina == 34)
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianNotaOperativo", _nParametros, _vParametros);
                            }
                            else
                            {
                                recordProcessed = data.executeCommand("pdbInfoDianNota", _nParametros, _vParametros);
                            }*/
                        }
                        catch (Exception ex)
                        {
                            ManejoError(ex, "var recordProcessed = data.executeCommand(\"pdbInfoDian\", _nParametros, _vParametros);");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return recordProcessed;
        }
        private bool procesarAnexos(LogReporteDian infoFactura)
        {
            bool anexos = false;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[3] { "p_numdoc_v", "p_oficina_n", "p_tipodoc_v" };
            _vParametros = new object[3] { infoFactura.LODI_LLAVE_V2, infoFactura.LODI_OFICINA_NB, "FC" };
            Factory data = new Factory(Usuario, Password, Ambiente);
            if (infoFactura.LODI_OFICINA_NB!=34)
            {
                var dtAnexos = data.getTable("FDB_LEER_ANEXOS_DIAN", _nParametros, _vParametros);
                if (dtAnexos.Rows.Count > 0)
                {
                    anexos = true;
                    foreach (DataRow dr in dtAnexos.Rows)
                    {
                        procesarAdjuntos(dr, infoFactura.LODI_LLAVE_V2);
                    }
                    //long sizeAnexo = comprimirAdjuntos(infoFactura.LODI_LLAVE_V2);
                }
                else
                {
                    anexos = false;
                }
            }
            return anexos;
        }
        private void procesarAdjuntos(DataRow dr, string factura)
        {
            long sizeAnexo = int.MinValue;
            try
            {
                string nombre = dr[0].ToString();
                string extension = dr[1].ToString();
                var mifile = dr[2];
                byte[] cadena_bytes = (byte[])mifile;
                Encoding.GetEncoding(1252).GetString(cadena_bytes);
                string x = Encoding.GetEncoding(1252).GetString(cadena_bytes);
                switch (extension)
                {
                    case "PDF":
                        {
                            try
                            {
                                string output = x.Substring(x.IndexOf("%PDF"));
                                int index = output.LastIndexOf("%%EOF");
                                if (index > 0)
                                    output = output.Substring(0, index + 5);
                                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                                System.IO.File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre, bytes);
                                sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre).Length;
                            }
                            catch (Exception ex)
                            {
                                string _mensajeError = "Se presento un error al momento de procesar los archivos adjunto asociados a la factura : " + factura + "\r\n";
                                _mensajeError += "Nombre del Archivo : " + nombre + "." + extension;
                                _mensajeError += @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                                //_log.wr(_vgp.directorio, "Exception.txt", _mensajeError);
                                //_correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                                SendEmail("Transer.Tecnologia.Automatizacion", _mensajeError, "fmontoya@transer.com.co", "jsoporte@transer.com.co", "francisco.montoya.l@gmail.com");
                            }
                            break;
                        }
                    default:
                        {
                            try
                            {
                                string output = x.Substring(x.IndexOf("%PDF"));
                                int index = output.LastIndexOf("%%EOF");
                                if (index > 0)
                                    output = output.Substring(0, index + 5);
                                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                                System.IO.File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre + ".pdf", bytes);
                                //sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre).Length;
                                sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre + ".pdf").Length;
                            }
                            catch (Exception ex)
                            {
                                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                                SendEmail("Transer.Tecnologia.Automatizacion", ex.Message, "fmontoya@transer.com.co", "jsoporte@transer.com.co", "francisco.montoya.l@gmail.com");
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                //_log.wr(_vgp.directorio, "Exception.txt", _mensajeError);
                //_correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
        }
        private long comprimirAdjuntos(string factura, InformacionDian informacionDian)
        {
            long sizeAnexo = int.MinValue;
            string ex1 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip";
            string ex2 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\*.*";
            string ejecucion = string.Empty;
            CallExecutes cmprmr = new CallExecutes();
            ejecucion = cmprmr.generarZIP(
                ex1,
                ex2);

            try
            {
                sizeAnexo = new System.IO.FileInfo(ex1).Length;
            }
            catch (IOException ex)
            {
                string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                ManejoError(ex, _mensajeError);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                ManejoError(ex, _mensajeError);

            }
            string infoCliente = getCliente(factura);
            if (sizeAnexo > 2300000 && sizeAnexo < 5000000)
            {


                using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\" + factura + ".txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(" Señor(es),  ");
                    writer.WriteLine(" " + infoCliente);
                    writer.WriteLine("  ");
                    writer.WriteLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Número de documento: " + factura);
                    writer.WriteLine(" Tipo de documento: " + "Factura");
                    writer.WriteLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
                    writer.WriteLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviaremos vía correo electrónico con el Asunto Factura(número de la factura)-Anexos al mismo correo donde reciben la notificación de la factura electrónica. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
                    writer.WriteLine("  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Atentamente,  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");
                }
                enviocorreo(factura, informacionDian.INDI_EMAIL_V2, factura + "-Anexos ", "", informacionDian.INDI_EMAIL_V2, "facturaciontranser@transer.com.co", "fmontoya@transer.com.co");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\" + factura + ".txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(" Señor(es),  ");
                    writer.WriteLine(" " + infoCliente);
                    writer.WriteLine("  ");
                    writer.WriteLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Número de documento: " + factura);
                    writer.WriteLine(" Tipo de documento: " + "Factura");
                    writer.WriteLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
                    writer.WriteLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviaremos vía correo electrónico con el Asunto Factura(número de la factura)-Anexos al mismo correo en que reciben la notificación de la factura electrónica. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
                    writer.WriteLine("  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Atentamente,  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");
                }
            }
            EliminarArchivosAdjuntos(factura);
            return sizeAnexo;
        }
        public bool comprimirFactura(string factura, string xml)
        {
            bool exitoso = true;
            try
            {
                string ex1 = "c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip";
                string ex2 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\*.*";
                using (StreamWriter writer = new StreamWriter("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + factura + ".xml"))
                {
                    writer.WriteLine(xml);
                }
                string ejecucion = string.Empty;
                CallExecutes cmprmr = new CallExecutes();
                ejecucion = cmprmr.generarZIP(ex1, ex2);
            }
            catch (Exception ex)
            {
                exitoso = false;
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                ManejoError(ex, _mensajeError);
            }
            return exitoso;
        }
        private string GetdataXmlAnexos(string factura)
        {
            string myxml = string.Empty;
            byte[] byteText = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");
            myxml = System.Convert.ToBase64String(byteText);
            File.WriteAllText("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".enc", myxml);
            string Base64String = File.ReadAllText("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".enc");

            byte[] array = System.Convert.FromBase64String(myxml); //Encoding.ASCII.GetBytes(Base64String);
            try
            {
                File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + "recuperado.zip", array);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                ManejoError(ex, _mensajeError);
            }
            return myxml;
        }
        private HttpsWebRequestsFunction MaquetarPaqueteSoap(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            httpwebrequestFunction._companyId = "860504882";
            httpwebrequestFunction._accountid = "860504882_01";
            httpwebrequestFunction._Username = "fmontoya@transer.com.co";
            httpwebrequestFunction._userId = "UsernameToken-1";
            EncodingFacturacionElectronica coding = new EncodingFacturacionElectronica();
            //httpwebrequestFunction._Password = coding.SHA256Encrypt("F935Cjm9262@");//produccion
            httpwebrequestFunction._Password = coding.SHA256Encrypt("Tys860504882@");//pruebas
            //httpwebrequestFunction._Password = coding.SHA256Encrypt("TranserFac@1"); //"Tys860504882@1";
            httpwebrequestFunction._HttpWebRequestFunction = "UploadRequest";
            httpwebrequestFunction._create = coding.getCreate();
            httpwebrequestFunction._nonce = coding.getNonce(httpwebrequestFunction._FileName);
            httpwebrequestFunction._soapEnviado = GetSoapEnvio(httpwebrequestFunction);
            return httpwebrequestFunction;
        }
        private HttpsWebRequestsFunction EnviarFactura(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            HttpSendXmlDocument httpsSendXmlDocument = new HttpSendXmlDocument();
            bool continuar = true;
            int intentos = 0;
            while (continuar)
            {                
                httpwebrequestFunction = httpsSendXmlDocument.httpsSendXmlDocument(httpwebrequestFunction);
                if (httpwebrequestFunction._httpWebResponseXml.Contains("error"))
                {
                    intentos++;
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    continuar = false;//<status>
                }
            }
            
            httpwebrequestFunction._soapRecibido = httpwebrequestFunction._httpWebResponseXml;
            return httpwebrequestFunction;
        }
        private string procesarNewXMLRecibido(HttpsWebRequestsFunction httpwebrequestFunction, LogReporteDian infoFactura)
        {
            string nombreArchivo = @"c:\transer\ws\facturacion\" + httpwebrequestFunction._Numdoc + "\\" + httpwebrequestFunction._Numdoc + "_xmlRecibido.xml";
            string status = string.Empty;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(httpwebrequestFunction._soapRecibido);
                doc.Save(nombreArchivo);
                XmlElement root = doc.DocumentElement;
                XmlNodeList elemListStatus = root.GetElementsByTagName("status");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListStatus.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._status = elemListStatus[i].InnerXml;
                    break;
                }
                XmlNodeList elemListTransactionId = root.GetElementsByTagName("transactionId");
                #pragma warning disable CS0162 // Se detectó código inaccesible
                for (int i = 0; i < elemListTransactionId.Count; i++)
                #pragma warning restore CS0162 // Se detectó código inaccesible
                {
                    httpwebrequestFunction._transactionId = elemListTransactionId[i].InnerXml;
                    break;
                }
                if (httpwebrequestFunction._status == "Archivo recibido con exito.")
                {
                    console.Ih("    !! Factura Enviada con Exito");
                    if (httpwebrequestFunction._transactionId.Length > 12)
                    {
                        //console.Ih("    !! actualizarlogReporteDian");
                        actualizarlogReporteDian("E", httpwebrequestFunction, infoFactura);
                    }
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
            }
            return status;
        }
        private void actualizarlogReporteDian(string estado, HttpsWebRequestsFunction httpwebrequestFunction, LogReporteDian infoFactura)
        {
            if (estado == "E")
            {
                console.Cgreen();
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    console.Ih("    !! Insertando Registro en la Tabla UPLOAD         ");
                    string[] _nParametros;
                    object[] _vParametros;
                    //:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta
                    _nParametros = new string[9] { ":filename", ":filedata", ":companyid", ":accountid", ":status", ":transactionid", ":xmlfactura", ":soapenviado", ":soaprespuesta" };
                    _vParametros = new object[9] { infoFactura.LODI_LLAVE_V2, httpwebrequestFunction._FileData, httpwebrequestFunction._companyId, httpwebrequestFunction._accountid, httpwebrequestFunction._status, httpwebrequestFunction._transactionId, httpwebrequestFunction._FacturaXml, httpwebrequestFunction._soapEnviado, httpwebrequestFunction._soapRecibido};
                    data.executeCommand("UploadRequestFE", _nParametros, _vParametros);
                }

                //_datos.executeDetLogDian(select.insertDetLogDian(), _vgp);
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    console.Ih("    !! Insertando Registro en la Tabla DetLogDian     ");
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[9] { ":secuencia", ":oficina", ":transaccion", ":llave", ":estado", ":iddian", ":cufe", ":soapEnviado", ":soapRecibido" };
                    _vParametros = new object[9] { infoFactura.LODI_SECUENCIA_NB, infoFactura.LODI_OFICINA_NB, infoFactura.LODI_TRANSACCION_NB, infoFactura.LODI_LLAVE_V2, infoFactura.LODI_ESTADO_V2, httpwebrequestFunction._transactionId, "EN PROCESO", httpwebrequestFunction._soapEnviado, httpwebrequestFunction._soapRecibido };
                    data.executeCommand("insertDetLogDian", _nParametros, _vParametros);
                }

                //_datos.executeUpdateInfoDian(select.updateInformacionDian(), _vgp);
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    console.Ih("    !! Insertando Registro en la Tabla InformacionDian");
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[3] { ":INDI_IDCARVAJAL", "INDI_CUFEDIAN", ":INDI_NUMDOC" };
                    _vParametros = new object[3] { httpwebrequestFunction._transactionId,"EN PROCESO", infoFactura.LODI_LLAVE_V2 };
                    data.executeCommand("updateInformacionDian", _nParametros, _vParametros);
                }
                //System.Threading.Thread.Sleep(3000);
                ILogicaInfoFactura Lif = new LogicaInfoFactura(Usuario, Password, UsuEmail, PassEmail, Ambiente);
                string cufe = string.Empty;
                cufe = Lif.Inicio(infoFactura.LODI_LLAVE_V2);
            }
            else
            {
                //Falta Implementar.....
            }
        }
        private string GetSoapEnvio(HttpsWebRequestsFunction httpwebrequestFunction)
        {
            StringBuilder select = new StringBuilder();
            select.Append("<soapenv:Envelope\r\n");
            select.Append("xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"\r\n");
            select.Append("xmlns:inv=\"http://invoice.carvajal.com/invoiceService/\"\r\n");
            select.Append("xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("secext-1.0.xsd\"\r\n");
            select.Append("xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("utility-1.0.xsd\">\r\n");
            select.Append("   <soapenv:Header>\r\n");
            select.Append("   <wsse:Security>\r\n");
            select.Append("   <wsse:UsernameToken wsu:Id=\"" + httpwebrequestFunction._userId + "\">\r\n"); // vgs.upload._userId
            select.Append("   	<wsse:Username>" + httpwebrequestFunction._Username + "</wsse:Username>\r\n");
            select.Append("<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-");
            select.Append("wss-username-token-profile-");
            select.Append("1.0#PasswordText\">" + httpwebrequestFunction._Password + "</w");
            select.Append("sse:Password>\r\n");
            select.Append("	<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-");
            select.Append("200401-wss-soap-message-security-");
            select.Append("1.0#Base64Binary\">" + httpwebrequestFunction._nonce + "</wsse:Nonce>\r\n");
            select.Append("		<wsu:Created>" + httpwebrequestFunction._create + "</wsu:Created>\r\n");
            select.Append("		</wsse:UsernameToken>\r\n");
            select.Append("		</wsse:Security>\r\n");
            select.Append("   </soapenv:Header>\r\n");
            select.Append("   <soapenv:Body>\r\n");
            select.Append("      <inv:" + httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");//sb.Append("      <inv:UploadRequest>\r\n");
            select.Append("         <fileName>" + httpwebrequestFunction._FileName + "</fileName>\r\n");
            select.Append("         <fileData>" + httpwebrequestFunction._FileData + "</fileData>\r\n");
            select.Append("         <companyId>" + httpwebrequestFunction._companyId + "</companyId>\r\n");
            select.Append("         <accountId>" + httpwebrequestFunction._accountid + "</accountId>\r\n");
            select.Append("      </inv:" + httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");//sb.Append("      </inv:UploadRequest>\r\n");
            select.Append("   </soapenv:Body>\r\n");
            select.Append("</soapenv:Envelope>");
            return select.ToString();
        }
        private void EliminarArchivosAdjuntos(string factura)
        {
            try
            {
                string[] filePaths = Directory.GetFiles("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\");
                foreach (string filePath in filePaths)
                {
                    if (filePath.Contains(".pdf"))
                    {
                        File.Delete(filePath);
                    }
                    if (filePath.Contains(".PDF"))
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (IOException ex)
            {
                string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                ManejoError(ex, _mensajeError);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                ManejoError(ex, _mensajeError);
            }

        }
        private string getCliente(string factura)
        {
            string cliente = string.Empty;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":factura" };
            _vParametros = new object[1] { factura };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getCliente", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        cliente = item[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return cliente;
        }
        private void enviocorreo(string factura, string correoCliente, string asunto, string mensaje, string para, string copia, string copiaOculta)
        {
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            /*cfEmail.user = "robotcorreo";
            cfEmail.password = "Tys860504882";*/
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            //cfEmail.Para = "FMONTOYA@TRANSER.COM.CO";
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            addLog(Correo.MensajeError);
            //byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");
            byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip");
            MailAttachment attach = new MailAttachment(byteTextAnexos, "anexos_" + factura + ".zip");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Señor(es),  ");
            sb.AppendLine(correoCliente);
            sb.AppendLine("  ");
            sb.AppendLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Número de documento: " + factura);
            sb.AppendLine(" Tipo de documento: FACTURA");
            sb.AppendLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
            sb.AppendLine("  ");
            sb.AppendLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviamos anexos al presente mensaje. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
            sb.AppendLine("  ");
            sb.AppendLine("  ");
            sb.AppendLine(" Atentamente,  ");
            sb.AppendLine("  ");
            sb.AppendLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");

            cfEmail.Mensaje = sb.ToString();

            Correo.SendMail(cfEmail, attach);

        }
        private void addLog(string texto)
        {
            Log += DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToLongTimeString() + "\r\n";
            Log += "Procesando " + P() + "\r\n";
            Log += texto + "\r\n";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Log);
            Log = string.Empty;
        }
        private string P()
        {
            Random r = new Random();
            string p = string.Empty;
            for (int i = 0; i < r.Next(1, 4); i++)
            {
                p += ".";
            }
            return p;
        }
        private bool SendEmail(string asunto, string mensaje, string para, string copia, string copiaOculta)
        {
            //SendEmail("Transer.Tecnologia.Automatizacion", ex.Message, "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.Mensaje = mensaje;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = UsuEmail;
            cfEmail.password = PassEmail;
            //cfEmail.Para = "FMONTOYA@TRANSER.COM.CO";
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            //addLog(Correo.MensajeError);
            return Correo.SendMail(cfEmail);
        }
    }
}
