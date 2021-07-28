using System;
using System.Text;
namespace Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio
{
    public class WsRndc
    {
        public string enviar(string xml)
        {
            int logMax = 600;
            string xml_respuesta = "";
            bool continuar = true;
            StringBuilder Mensaje = new StringBuilder();
            try
            {
                Mensaje.Append("         Estableciendo Comunicacion con el Web Services del Ministerio    \r\n");
                Mensaje.Append("         ============= ============ === == === ======== === ==========    \r\n");
                if (xml.Length < logMax)
                { Mensaje.Append(xml); }
                else
                {
                    Mensaje.Append(xml.Substring(0, logMax));
                }
                srRndc.BPMServicesClient envio_xml = new srRndc.BPMServicesClient();
                while (continuar)
                {
                    xml_respuesta = envio_xml.AtenderMensajeRNDC(xml);
                    if (xml_respuesta.Contains("Se ha terminado la conexión: La conexión ha terminado de forma inesperada"))
                    {
                        Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                        Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                        Mensaje.Append("\r\n");
                        Mensaje.Append("\r\nDetalle del error.\r\n");
                        if (xml_respuesta.Length < logMax)
                        { Mensaje.Append(xml_respuesta); }
                        else
                        {
                            Mensaje.Append(xml_respuesta.Substring(0, logMax));
                        }
                        continuar = true;
                    }
                    else
                    {
                        if (xml_respuesta.Contains("No se puede atender la solicitud"))
                        {
                            Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                            Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                            Mensaje.Append("\r\n");
                            Mensaje.Append("\r\nDetalle del error.\r\n");
                            if (xml_respuesta.Length < logMax)
                            { Mensaje.Append(xml_respuesta); }
                            else
                            {
                                Mensaje.Append(xml_respuesta.Substring(0, logMax));
                            }
                            continuar = true;
                        }
                        else
                        {
                            if (xml_respuesta.Contains("I/O error 103"))
                            {
                                Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                                Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                                Mensaje.Append("\r\n");
                                Mensaje.Append("\r\nDetalle del error.\r\n");
                                if (xml_respuesta.Length < logMax)
                                { Mensaje.Append(xml_respuesta); }
                                else
                                {
                                    Mensaje.Append(xml_respuesta.Substring(0, logMax));
                                }
                                continuar = true;
                            }
                            else
                            {
                                if (xml_respuesta.Contains("Se ha terminado la conexión"))
                                {
                                    Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                                    Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                                    Mensaje.Append("\r\n");
                                    Mensaje.Append("\r\nDetalle del error.\r\n");
                                    if (xml_respuesta.Length < logMax)
                                    { Mensaje.Append(xml_respuesta); }
                                    else
                                    {
                                        Mensaje.Append(xml_respuesta.Substring(0, logMax));
                                    }
                                    continuar = true;
                                }
                                else
                                {
                                    Mensaje.Clear();
                                    Mensaje.Append("         TRANSACCION ENVIADA CON EXITO    \r\n");
                                    Mensaje.Append("         =========== ======= === =====    \r\n");
                                    Mensaje.Append("\r\n");
                                    Mensaje.Append("\r\nRespuesta.\r\n");
                                    if (xml_respuesta.Length < logMax)
                                    { Mensaje.Append(xml_respuesta); }
                                    else
                                    {
                                        Mensaje.Append(xml_respuesta.Substring(0, logMax));
                                    }
                                    continuar = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                string _mensajeError = @"El Web service del ministerio de transporte, " + "Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caMinisterio_enviar_dato" + "\r\nXML : \r\n" + xml;
                //_log.wr(_vgp._directorio, "Exception.txt", _mensajeError);
                //Correo _correo = new Correo(_vgp);
                Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                Mensaje.Append("\r\n");
                Mensaje.Append("\r\nDetalle del error.\r\n");
                if (_mensajeError.Length < logMax)
                { Mensaje.Append(_mensajeError); }
                else
                {
                    Mensaje.Append(_mensajeError.Substring(0, logMax));
                }
                //_correo.envioCorreoDesarrollador("srRndc1.BPMServicesClient " + ex.Message, _mensajeError, _vgp);
                xml_respuesta = ex.Message;
            }
            catch (Exception ex)
            {
                //Console.Clear();
                string _mensajeError = @"El Web service del ministerio de transporte, " + "Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caMinisterio_enviar_dato" + "\r\nXML : \r\n" + xml;
                //_log.wr(_vgp._directorio, "Exception.txt", _mensajeError);
                //Correo _correo = new Correo(_vgp);
                Mensaje.Append("         SE PRESENTO UN ERROR EN LA CONEXION CON EL WEB SERVICES DEL MINISTERIO    \r\n");
                Mensaje.Append("         == ======== == ===== == == ======== === == === ======== === ==========    \r\n");
                Mensaje.Append("\r\n");
                Mensaje.Append("\r\nDetalle del error.\r\n");
                if (_mensajeError.Length < logMax)
                { Mensaje.Append(_mensajeError); }
                else
                {
                    Mensaje.Append(_mensajeError.Substring(0, logMax));
                }
                //_correo.envioCorreoDesarrollador("srRndc1.BPMServicesClient " + ex.Message, _mensajeError, _vgp);
                xml_respuesta = ex.Message;
            }
            return xml_respuesta;
        }

    }
}
