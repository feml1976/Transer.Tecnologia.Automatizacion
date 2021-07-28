using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using Transer.Tecnologia.Automatizacion.Entity;

namespace Transer.Tecnologia.Automatizacion.Correo
{
    public class CorreoElectronico
    {
        public string MensajeError { get; set; }
        //private string UsuEmail;
        //private string PassEmail;
        /*public CorreoElectronico(string usuEmail, string passEmail)
        {
            UsuEmail = usuEmail;
            PassEmail = passEmail;
        }*/
        public bool SendMail(ConfiguracionEmail cfEmail)
        {
            bool CorreoExitoso = false;
            EnviarCorreo(cfEmail);
            return CorreoExitoso;
        }
        
        public bool SendMail(ConfiguracionEmail cfEmail, List<MailAttachment> attachments)
        {
            bool CorreoExitoso = false;
            EnviarCorreo(cfEmail, attachments);
            return CorreoExitoso;
        }
        public bool SendMail(ConfiguracionEmail cfEmail, params MailAttachment[] attachments)
        {
            bool CorreoExitoso = false;
            EnviarCorreo(cfEmail, attachments);
            return CorreoExitoso;
        }
        private bool EnviarCorreo(ConfiguracionEmail cfEmail)
        {
            bool CorreoExitoso = true;
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("fmontoya@transer.com.co");
            msg.To.Add(cfEmail.Para);            
            msg.CC.Add(cfEmail.Copia);
            msg.Bcc.Add(cfEmail.CopiaOculta);
            msg.From = new MailAddress(cfEmail.cuentaCorreo, cfEmail.Titulo, System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = cfEmail.Asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cfEmail.Mensaje;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            Security security = new Security();
            client.Credentials = new System.Net.NetworkCredential(security.Base64Decode(cfEmail.user), security.Base64Decode(cfEmail.password));
            client.Port = cfEmail.port;
            client.Host = cfEmail.host;
            client.EnableSsl = cfEmail.enableSsl;
            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo SmtpException\r\n" + ex.Message;
            }
            catch (Exception ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo Exception\r\n" + ex.Message;
            }
            #endregion // fin del Envio de correo

            return CorreoExitoso;
        }
        

        private bool EnviarCorreo(ConfiguracionEmail cfEmail, List<MailAttachment> attachments)
        {
            bool CorreoExitoso = true;
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add("fmontoya@transer.com.co");
            msg.To.Add(cfEmail.Para);
            //msg.CC.Add(cfEmail.Copia);
            msg.Bcc.Add(cfEmail.CopiaOculta);
            msg.From = new MailAddress(cfEmail.cuentaCorreo, cfEmail.Titulo, System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = cfEmail.Asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cfEmail.Mensaje;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            //msg.IsBodyHtml = false;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            Security security = new Security();
            client.Credentials = new System.Net.NetworkCredential(security.Base64Decode(cfEmail.user), security.Base64Decode(cfEmail.password));
            client.Port = cfEmail.port;
            client.Host = cfEmail.host;
            client.EnableSsl = cfEmail.enableSsl;

            try
            {
                foreach (MailAttachment ma in attachments)
                {
                    msg.Attachments.Add(ma.File);
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:fmontoya@transer.com.co");
                sb.Append("\nbody:" + cfEmail.Mensaje);
                sb.Append("\nsubject:" + cfEmail.Asunto);
                sb.Append("\nfromAddress:robotcorreo@transer.com.co");
                sb.Append("\nfromDisplay:Robot Correo");
                sb.Append("\ncredentialUser:" + cfEmail.user);
                sb.Append("\ncredentialPasswordto:" + cfEmail.password);
                sb.Append("\nHosting:192.168.30.8");
                using (StreamWriter writer =
                        new StreamWriter(@"C:\Transer\ws\facturacion\errorCorreo.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(sb.ToString() + ex.ToString());
                    writer.WriteLine("*");
                    writer.WriteLine(" ");
                }
            }

            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo SmtpException\r\n" + ex.Message;
            }
            catch (Exception ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo Exception\r\n" + ex.Message;
            }
            #endregion // fin del Envio de correo

            return CorreoExitoso;
        }
        private bool EnviarCorreo(ConfiguracionEmail cfEmail, params MailAttachment[] attachments)
        {
            bool CorreoExitoso = true;
            #region Envio de correo
            MailMessage msg = new MailMessage();
            msg.To.Add("fmontoya@transer.com.co");
            /*msg.To.Add(cfEmail.Para);
            msg.CC.Add(cfEmail.Copia);
            msg.Bcc.Add(cfEmail.CopiaOculta);*/
            msg.From = new MailAddress(cfEmail.cuentaCorreo, cfEmail.Titulo, System.Text.Encoding.UTF8);
            try
            {
                msg.Subject = cfEmail.Asunto;
            }
            catch (Exception ex)
            {
                msg.Subject = ex.Message;
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cfEmail.Mensaje;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            Security security = new Security();
            client.Credentials = new System.Net.NetworkCredential(security.Base64Decode(cfEmail.user), security.Base64Decode(cfEmail.password));
            client.Port = cfEmail.port;
            client.Host = cfEmail.host;
            client.EnableSsl = cfEmail.enableSsl;

            try
            {
                foreach (MailAttachment ma in attachments)
                {
                    msg.Attachments.Add(ma.File);
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:fmontoya@transer.com.co");
                sb.Append("\nbody:" + cfEmail.Mensaje);
                sb.Append("\nsubject:" + cfEmail.Asunto);
                sb.Append("\nfromAddress:robotcorreo@transer.com.co");
                sb.Append("\nfromDisplay:Robot Correo");
                sb.Append("\ncredentialUser:" + cfEmail.user);
                sb.Append("\ncredentialPasswordto:" + cfEmail.password);
                sb.Append("\nHosting:192.168.30.8");
                using (StreamWriter writer =
                        new StreamWriter(@"C:\Transer\ws\facturacion\errorCorreo.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(sb.ToString() + ex.ToString());
                    writer.WriteLine("*");
                    writer.WriteLine(" ");
                }
            }

            try
            {
                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo SmtpException\r\n" + ex.Message;
            }
            catch (Exception ex)
            {
                CorreoExitoso = false;
                MensajeError = "Excepcion de tipo Exception\r\n" + ex.Message;
            }
            #endregion // fin del Envio de correo

            return CorreoExitoso;
        }
    }
    internal class Security
    {
        public Security()
        {
            
        }

        public string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            /*var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);*/
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string texto = System.Convert.ToBase64String(plainTextBytes);
            return texto;
        }
    }

}
