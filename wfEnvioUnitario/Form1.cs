using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace wfEnvioUnitario
{
    public partial class Form1 : Form
    {
        public string Funcion { get; set; }
        public LogReporteMinisterio _logReporteMinisterio { get; set; }
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }

        public int Transaccion { get; set; }
        public string Llave { get; set; }
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DataTable dtcbxTransaccion = new DataTable();
            dtcbxTransaccion.Columns.Add("Nombre", typeof(string));
            dtcbxTransaccion.Columns.Add("Codigo", typeof(int));
            dtcbxTransaccion.Rows.Add("Orden de Cargue", 3);
            dtcbxTransaccion.Rows.Add("Manifiesto de Cargue", 4);
            dtcbxTransaccion.Rows.Add("Cumplido Orden", 5);
            dtcbxTransaccion.Rows.Add("Cumplido Planilla", 6);
            dtcbxTransaccion.Rows.Add("Anular Remesa", 9);
            dtcbxTransaccion.Rows.Add("Propietario Nit", 10);
            dtcbxTransaccion.Rows.Add("Propietario Cedula", 11);
            dtcbxTransaccion.Rows.Add("Conductor", 12);
            dtcbxTransaccion.Rows.Add("Cliente Nit", 13);
            dtcbxTransaccion.Rows.Add("Cliente Cedula", 14);
            dtcbxTransaccion.Rows.Add("Vehiculo", 15);
            dtcbxTransaccion.Rows.Add("Trailer", 16);
            dtcbxTransaccion.Rows.Add("Anular Planilla", 32);
            cbxTransaccion.ValueMember = "Codigo";
            cbxTransaccion.DisplayMember = "Nombre";
            cbxTransaccion.DataSource = dtcbxTransaccion;
            SecurityPrvt security = new SecurityPrvt();
            Usuario = security.Decode("fmontoya");
            Password = security.Decode("f935cjm9262");
            UsuEmail = security.Decode("robotcorreo");
            PassEmail = security.Decode("Tys860504882");
            Ambiente = security.Decode("produccion");
        }

        private void cbxTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbXmlEnviar.Text = string.Empty;
            txbXmlRecibido.Text = string.Empty;
            Transaccion = (int)cbxTransaccion.SelectedValue;
            txbLlave.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            txbXmlEnviar.Text = string.Empty;
            txbXmlRecibido.Text = string.Empty;
            Llave = txbLlave.Text;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_TRANSACCION", ":LRMI_LLAVE" };
            _vParametros = new object[2] { Transaccion, Llave };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getLogReporteMinisterioTransaccionLlave", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    txbXmlEnviar.Enabled = true;
                    foreach (DataRow item in dt.Rows)
                    {
                        LogReporteMinisterio p = new LogReporteMinisterio();
                        p.LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                        p.LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                        p.LRMI_TRANSACCION_NB = int.Parse(item["LRMI_TRANSACCION_NB"].ToString());
                        p.LRMI_LLAVE_V2 = item["LRMI_LLAVE_V2"].ToString();
                        p.LRMI_FECREGISTRO_DT = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
                        p.LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
                        try
                        {
                            p.LRMI_CAMPO1_NB = double.Parse(item["LRMI_CAMPO1_NB"].ToString());
                        }
                        catch (Exception ex)
                        {
                            p.LRMI_CAMPO1_NB = -1;
                        }
                        
                        p.LRMI_CAMPO2_V2 = item["LRMI_CAMPO2_V2"].ToString();
                        try
                        {
                            p.LRMI_CAMPO3_DT = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
                        }
                        catch (Exception EX)
                        {
                            p.LRMI_CAMPO3_DT = DateTime.Now;
                        }
                        
                        _logReporteMinisterio = p;
                        
                        procesarRegistro(p);
                    }
                }
                else
                {
                    txbXmlEnviar.Text = "La consulta no devolvio valores";
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteMinisterio = data.getTable(\"getLogReporteMinisterio\", _nParametros, _vParametros);");
            }
        }
        private void procesarRegistro(LogReporteMinisterio p)
        {
            DataTable dt_datos = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_LLAVE" };
            _vParametros = new object[1] { p.LRMI_LLAVE_V2 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            string funcion = string.Empty;
            switch (p.LRMI_TRANSACCION_NB)
            {
                case 3:
                    {
                        funcion = "PK_MINISTERIO_XML_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 4:
                    {
                        funcion = "PK_MINISTERIO_XML_MANIFIESTO_CARGA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 5:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIDO_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 6:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 9:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }

                case 10:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 11:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 12:
                    {
                        funcion = "PK_MINISTERIO_XML_CONDUCTORES";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 13:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 14:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 15:
                    {
                        funcion = "PK_MINISTERIO_XML_VEHICULOS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 16:
                    {
                        funcion = "PK_MINISTERIO_XML_TRAILERS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 32:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            Funcion = funcion;
        }
        private void procesarFuncion(string funcion, DataRow drw, LogReporteMinisterio p)
        {
            string rutaArchivo = @"c:\transer\ws\web_ministerio\XML_" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + p.LRMI_OFICINA_NB + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            WsRndc srRndc = new WsRndc();
            switch (funcion)
            {
                case "PK_MINISTERIO_XML_REMESA"://3
                    {
                        try
                        {
                            xml_envio = gxml.procesar_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA"://4
                    {
                        try
                        {
                            xml_envio = gxml.procesar_manifiesto_carga(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA"://5
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplido_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO"://6
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplir_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT"://10
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA"://11
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES"://12
                    {
                        try
                        {
                            xml_envio = gxml.procesar_conductores(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT"://13
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA"://14
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS"://16
                    {
                        try
                        {
                            xml_envio = gxml.procesar_vehiculos(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS"://17
                    {
                        try
                        {
                            xml_envio = gxml.procesar_trailers(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }

                case "PK_MINISTERIO_XML_ANULAR_REMESA"://9
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO"://32
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            txbXmlEnviar.Text = xml_envio;
                            btnEnviar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
        }

        private void txbLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//validamos si se presiono la tecla enter
            {
                Buscar();
            }
        }

        private class SecurityPrvt
        {
            public SecurityPrvt()
            {

            }
            public string Decode(string texto)
            {
                string codigo = string.Empty;
                switch (texto)
                {
                    case "usuario":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "password":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "usuEmail":
                        {
                            codigo = Base64Decode("robotcorreo");
                            break;
                        }
                    case "passEmail":
                        {
                            codigo = Base64Decode("Tys860504882");
                            break;
                        }
                    default:
                        {
                            codigo = Base64Decode(texto);
                            break;
                        }
                }
                return codigo;
            }
            private string Base64Decode(string base64EncodedData)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(base64EncodedData);
                //string encodedText = Convert.ToBase64String(plainTextBytes);
                return Convert.ToBase64String(plainTextBytes);
                //return System.Text.Encoding.UTF8.GetString(plainTextBytes);
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            GenerarXml gxml = new GenerarXml();
            WsRndc srRndc = new WsRndc();
            string xml_recibido = srRndc.enviar(txbXmlEnviar.Text);
            txbXmlRecibido.Text = xml_recibido;
            procesarEnvioMinisterio(Funcion, txbXmlEnviar.Text, xml_recibido, _logReporteMinisterio);
            txbXmlRecibido.Enabled = true;
        }

        private void procesarEnvioMinisterio(string v, string xml_envio, string xml_recibido, LogReporteMinisterio p)
        {
            string ruta = @"c:\transer\ws\web_ministerio\" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";
            bool continuar = false;
            GenerarXml gxml = new GenerarXml();
            //string LRMI_ESTADO = string.Empty;
            double DELM_IDMINISTERIO = -1234567890;
            #region Definicion de carga del documento XmlDocument xmlReturn

            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
                continuar = true;
            }
            catch (XmlException ex)
            {
                try
                {
                    xml_recibido = gxml.maquetarXMLError(xml_recibido, -2, "P", p);
                    xmlReturn.LoadXml(xml_recibido);
                    continuar = true;
                }
                catch (Exception exx)
                {

                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                continuar = false;
            }
            #endregion fin de la Definicion de carga del documento XmlDocument xmlReturn
            #region Definicion del bloque procesar respuesta
            while (continuar)
            {
                XmlElement root = xmlReturn.DocumentElement;
                try
                {
                    xmlReturn.Save(ruta);
                }
                catch (Exception ex)
                {

                }
                if (continuar)
                {
                    XmlNodeList elemListErrorTYS = root.GetElementsByTagName("ErrorTYS");
                    if (elemListErrorTYS.Count > 0)
                    {
                        /*console.Cblue();
                        console.Ih(" ", false);
                        console.Ih("==> XML Recibido ", true);
                        console.Ih("    *** " + xml_recibido, false);*/


                        XmlNodeList elemListEstadoRegistro = root.GetElementsByTagName("EstadoRegistro");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListEstadoRegistro.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            //httpwebrequestFunction._status = elemListErrorTYS[i].InnerXml;
                            p.LRMI_ESTADO_V2 = elemListEstadoRegistro[i].InnerXml;
                            continuar = false;
                            break;
                        }
                        XmlNodeList elemListCodigoError = root.GetElementsByTagName("CodigoError");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListCodigoError.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListCodigoError[i].InnerXml.ToString());
                            continuar = false;
                            break;
                        }
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        if (elemListErrorMSG[i].InnerXml.ToString().Contains("DUPLICADO"))
                        {
                            p.LRMI_ESTADO_V2 = "E";
                            DELM_IDMINISTERIO = getId(elemListErrorMSG[i].InnerXml.ToString());
                        }
                        else
                        {
                            p.LRMI_ESTADO_V2 = "R";
                            DELM_IDMINISTERIO = -1;
                        }
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListingresoid = root.GetElementsByTagName("ingresoid");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListingresoid.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        p.LRMI_ESTADO_V2 = "E";
                        try
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListingresoid[i].InnerXml);
                        }
                        catch (Exception ex)
                        {
                            DELM_IDMINISTERIO = -123456;
                        }
                        continuar = false;
                        break;
                    }
                }
            }

            if (DELM_IDMINISTERIO == -1234567890)
            {
                continuar = false;
            }
            else
            {
                continuar = true;
            }

            #endregion fin de la Definicion del bloque procesar respuesta

            if (continuar && p.LRMI_ESTADO_V2 != "P")
            {
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    string[] _nParametros;
                    object[] _vParametros;
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                        _vParametros = new object[3] { "F", p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        try
                        {
                            data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                        }
                        catch (Exception ex)
                        {
                            continuar = false;
                        }
                    }
                    else
                    {
                        if (p.LRMI_ESTADO_V2 != "R")
                        {
                            if (p.LRMI_CAMPO1_NB == 1)
                            {
                                p.LRMI_CAMPO1_NB = 2;
                                _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_CAMPO1", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[4] { p.LRMI_ESTADO_V2, p.LRMI_CAMPO1_NB, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    data.executeCommand("UpdateLogReporteMinisterioCampo1", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    continuar = false;
                                }
                            }
                            else
                            {
                                //p.LRMI_CAMPO1_NB = 0;
                                _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[3] { p.LRMI_ESTADO_V2, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    continuar = false;
                                }
                            }
                        }
                        else
                        {
                            _nParametros = new string[3] { ":LRMI_ESTADO", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                            _vParametros = new object[3] { p.LRMI_ESTADO_V2, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                            try
                            {
                                data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                            }
                            catch (Exception ex)
                            {
                                continuar = false;
                            }
                        }
                    }
                }
            }
            if (continuar)
            {
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    //console.Ih("    !! Insertando Registro en la Tabla DetLogMinisterio         ");
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[9] { ":secuencia", ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB", ":LRMI_TRANSACCION_NB", ":LRMI_LLAVE_V2", ":LRMI_ESTADO_V2", ":DELM_IDMINISTERIO_NB", ":DELM_XMLENVIADO_XML", ":DELM_XMLRECIBIDO_XML" };
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, gxml.getXmlEnvioFletx(xml_envio, p), gxml.getXmlRecibidoFletx(xml_recibido, p) };
                    }
                    else
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, xml_envio, xml_recibido };
                    }
                    try
                    {
                        data.executeCommand("InsertDetLogMinisterio", _nParametros, _vParametros);
                    }
                    catch (Exception)
                    {
                        continuar = false;
                    }
                }
            }
        }
        private void procesarSelectSinValores(string funcion, LogReporteMinisterio p)
        {
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            xml_envio = gxml.SelectSinValores(funcion, p);
            xml_recibido = gxml.ReturnSinValores(funcion, -3, "R", p);
            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
        }
        private double getId(string xmlElement)
        {
            //DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
            double DELM_IDMINISTERIO_NB = -1;
            bool bid = false;
            string tid = string.Empty;
            for (int i = 9; i < xmlElement.Length; i++)
            {
                if (xmlElement.Substring(i, 1) == " ")
                {
                    DELM_IDMINISTERIO_NB = int.Parse(tid);
                    break;
                }
                if (bid)
                {
                    tid += xmlElement.Substring(i, 1);
                }
                if (xmlElement.Substring(i, 1) == ":")
                {
                    bid = true;
                }
            }
            return DELM_IDMINISTERIO_NB;
        }
        private double getSecuenciaDetLogMinisterio(LogReporteMinisterio p)
        {
            double delm_secuencia = 0;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB" };
            _vParametros = new object[2] { p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
            Factory data = new Factory(Usuario, Password, Ambiente);
            var dtDetLogMinisterio = data.getTable("getDetLogMinisterio", _nParametros, _vParametros);
            if (dtDetLogMinisterio.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetLogMinisterio.Rows)
                {
                    try
                    {
                        delm_secuencia = double.Parse(dr["DELM_SECUENCIA_NB"].ToString());
                    }
                    catch (Exception ex)
                    {
                        delm_secuencia = 0;
                    }
                }
                delm_secuencia++;
            }
            else
            {
                delm_secuencia = 1;
            }

            return delm_secuencia;
        }






    }
}
