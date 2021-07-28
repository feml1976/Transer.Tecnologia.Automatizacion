using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Transer.Tecnologia.Automatizacion.caFEVTysLogicaNegocio.Interfaces;
using Transer.Tecnologia.Automatizacion.Correo;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caFEVTysLogicaNegocio
{
    public partial class SendEmailFacturaClient : ISendEmailFacturaClient
    {
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public InformacionDian informacionDian { get; set; }
        public List<CorreosCopiaFactura> LcorreosCopiaFacturas { get; set; }
        public SendEmailFacturaClient(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
        }

        public bool SendMailClients(InformacionDian informacionDian)
        {
            //informacionDian.INDI_NUMDOC_V2 = "EBGT11781";
            //informacionDian.INDI_CLIENTE_NB = 668;
            //informacionDian.INDI_NOMCLIENTE_V2 = "ITALCOL S.A.";
            List<CorreosCopiaFactura> Lc = GetCorreosCopiaFactura(informacionDian);
            if (Lc.Count > 0)
            {
                foreach (CorreosCopiaFactura item in Lc)
                {
                    enviocorreo(informacionDian, item);
                }
            }
            else
            {
                CorreosCopiaFactura item = new CorreosCopiaFactura();
                item.COCF_EMAIL_V2 = "fmontoya@transer.com.co";
                enviocorreo(informacionDian, item);
            }
            return true;
        }
        private void enviocorreo(InformacionDian informacionDian, CorreosCopiaFactura item)
        {
            string logError = string.Empty;
            string factura = informacionDian.INDI_NUMDOC_V2;
            string correoCliente = informacionDian.INDI_NOMCLIENTE_V2;//getCliente(factura);
            string asunto = "TRANSPORTES Y SERVICIOS TRANSER S.A. Factura " + factura;
            string para = item.COCF_EMAIL_V2;
            string copia = "fmontoya@transer.com.co";
            string copiaOculta = "fmontoya@transer.com.co";

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
            //addLog(Correo.MensajeError);
            //byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");

            List<MailAttachment> LMailAttachment = new List<MailAttachment>();

            bool continua = true;
            bool pdf = false;
            bool cufe = false;
            int contador = 0;
            while (continua)
            {
                contador++;
                try
                {
                    byte[] byteTextPdf = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\pdf\\" + factura + ".pdf");
                    MailAttachment attachPdf = new MailAttachment(byteTextPdf, factura + ".pdf");
                    LMailAttachment.Add(attachPdf);
                    pdf = true;
                    continua = false;
                }
                catch (Exception ex)
                {
                    logError = ex.Message;
                    if (contador >= 10)
                    {
                        continua = false;
                    }
                    System.Threading.Thread.Sleep(3000);
                }

            }

            continua = true;
            contador = 0;
            while (continua)
            {
                contador++;
                try
                {
                    byte[] byteTextXml = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\cufe\\" + factura + ".xml");
                    MailAttachment attachXml = new MailAttachment(byteTextXml, factura + ".xml");
                    LMailAttachment.Add(attachXml);
                    cufe = true;
                    continua = false;
                }
                catch (Exception ex)
                {
                    logError = ex.Message;
                    if (contador >= 10)
                    {
                        continua = false;
                    }
                    System.Threading.Thread.Sleep(3000);
                }

            }

            continua = true;
            contador = 0;
            while (continua)
            {
                contador++;
                try
                {
                    byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip");
                    MailAttachment attach = new MailAttachment(byteTextAnexos, factura + ".zip");
                    LMailAttachment.Add(attach);
                    continua = false;
                }
                catch (Exception ex)
                {
                    logError = ex.Message;
                    if (contador >= 10)
                    {
                        continua = false;
                    }
                    System.Threading.Thread.Sleep(3000);
                }

            }

            /*byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip");
            MailAttachment attach = new MailAttachment(byteTextAnexos, "anexos_" + factura + ".zip");*/
            StringBuilder sb = new StringBuilder();
            /*
            sb.AppendLine("Señor(es),  ");
            sb.AppendLine(correoCliente);
            sb.AppendLine("  ");
            sb.AppendLine(" Le informamos ha recibido un documento de TRANSPORTES Y SERVICIOS TRANSER S.A. en CenFinanciero. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Número de documento: " + factura);
            sb.AppendLine(" Tipo de documento: Copia Factura de Venta ");
            sb.AppendLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
            sb.AppendLine("  ");
            sb.AppendLine("  Si requiere consultar, rechazar o aceptar el documento, ingrese al siguiente vinculo: https://cenf.cen.biz ");
            sb.AppendLine("  ");
            sb.AppendLine(" Si tiene alguna inquietud sobre la información contenida en la factura/nota electrónica no dude en comunicarse con nosotros  ");
            sb.AppendLine("  ");
            sb.AppendLine("  ");
            sb.AppendLine(" Atentamente,  ");
            sb.AppendLine("  ");
            sb.AppendLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");
            */

            sb.AppendLine("Señor(es),  ");
            sb.AppendLine("<h3 style=\"font - family:verdana;\">" + correoCliente + "</h3>");
            sb.AppendLine("  ");
            sb.AppendLine("<p style=\"font - family:verdana;\">Le informamos ha recibido un documento de TRANSPORTES Y SERVICIOS TRANSER S.A. en CenFinanciero.</p>");
            sb.AppendLine("  ");
            sb.AppendLine("<h5 style=\"font - family:verdana;\">Número de documento: " + factura + "</h3>");
            sb.AppendLine("<h5 style=\"font - family:verdana;\">Tipo de documento: Copia Factura de Venta </h3>");
            sb.AppendLine("<h5 style=\"font - family:verdana;\">Fecha de emisión: " + DateTime.Now.ToLongDateString() + "</h3>");
            sb.AppendLine("<p style=\"font - family:courier;\">  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">Si requiere consultar, rechazar o aceptar el documento, ingrese al siguiente vinculo: https://cenf.cen.biz </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">Si tiene alguna inquietud sobre la información contenida en la factura/nota electrónica no dude en comunicarse con nosotros  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">Atentamente,  </p>");
            sb.AppendLine("<p style=\"font - family:verdana;\">  </p>");
            sb.AppendLine("<h2 style=\"font - family:verdana;\">TRANSPORTES Y SERVICIOS TRANSER S.A </h3>");
            //sb.AppendLine("<img src=\"C:\\Desarrollos\\imagenes\\firmaTranser.PNG\" alt=\"TRANSER S.A\">");

            cfEmail.Mensaje = sb.ToString();
            if (cufe&&pdf)
            {
                Correo.SendMail(cfEmail, LMailAttachment);
            }
            else
            {
                cufe = false;
                pdf = false;
            }

        }
        /*private void EnviarCorreo(InformacionDian informacionDian, CorreosCopiaFactura item)
        {
            Correo.SendMail(cfEmail, attach);
        }*/

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

        private List<CorreosCopiaFactura> GetCorreosCopiaFactura(InformacionDian informacionDian)
        {
            List<CorreosCopiaFactura> LCorreosCopiaFacturas = new List<CorreosCopiaFactura>();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":COCF_CLIENTE" };
            _vParametros = new object[1] { informacionDian.INDI_CLIENTE_NB };
            //_vParametros = new object[1] { 323 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getInformacionCorreoClientes", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            LCorreosCopiaFacturas.Add(addCorreosCopiaFacturas(item));
                        }
                        catch (Exception exx)
                        {

                            ManejoError(exx, "ICInformacionDian.Add(addInformacionDian(item));");
                        }
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }

            return LCorreosCopiaFacturas;
        }

        private CorreosCopiaFactura addCorreosCopiaFacturas(DataRow item)
        {
            CorreosCopiaFactura correosCopiaFactura = new CorreosCopiaFactura();
            try
            {
                correosCopiaFactura.COCF_SECUENCIA_NB = double.Parse(item["COCF_SECUENCIA_NB"].ToString());
            }
            catch (Exception ex)
            {

                correosCopiaFactura.COCF_SECUENCIA_NB = double.MinValue;
            }
            try
            {
                correosCopiaFactura.COCF_CLIENTE_NB = int.Parse(item["COCF_CLIENTE_NB"].ToString());
            }
            catch (Exception ex)
            {

                correosCopiaFactura.COCF_CLIENTE_NB = int.MinValue;
            }
            try
            {
                correosCopiaFactura.COCF_EMAIL_V2 = item["COCF_EMAIL_V2"].ToString();
            }
            catch (Exception ex)
            {
                correosCopiaFactura.COCF_EMAIL_V2 = string.Empty;
            }
            try
            {
                correosCopiaFactura.COCF_ESTADO_V2 = item["COCF_ESTADO_V2"].ToString();
            }
            catch (Exception ex)
            {

                correosCopiaFactura.COCF_ESTADO_V2 = string.Empty;
            }
            try
            {
                correosCopiaFactura.COCF_FECCREA_DT = DateTime.Parse(item["COCF_FECCREA_DT"].ToString());
            }
            catch (Exception ex)
            {

                correosCopiaFactura.COCF_FECCREA_DT = DateTime.Now;
            }

            try
            {
                correosCopiaFactura.COCF_USUCREA_NB = double.Parse(item["COCF_USUCREA_NB"].ToString());
            }
            catch (Exception ex)
            {

                correosCopiaFactura.COCF_USUCREA_NB = double.MinValue;
            }

            try
            {
                correosCopiaFactura.COCF_USUANULA_NB = double.Parse(item["COCF_USUANULA_NB"].ToString());
            }
            catch (Exception ex)
            {
                correosCopiaFactura.COCF_USUANULA_NB = double.MinValue;
            }
            try
            {
                correosCopiaFactura.COCF_FECANULA_DT = DateTime.Parse(item["COCF_FECANULA_DT"].ToString());
            }
            catch (Exception ex)
            {
                correosCopiaFactura.COCF_FECANULA_DT = DateTime.Now;
            }

            return correosCopiaFactura;
        }
        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            //console.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
        }

    }
}
