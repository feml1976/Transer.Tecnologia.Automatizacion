using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura;
using Transer.Tecnologia.Automatizacion.EncodingFE;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caFEVTysLogicaNegocio
{
    public partial class LogicaNegocio : ILogicaNegocio
    {
        /*VERSION PRODUCCION*/

        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public ICollection<LogReporteDian> ICLogReporteDian { get; set; }
        public Consola console;
        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {

            //SendEmail("Pruebas", "Mensaje de prueba", "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            console = new Consola("        Facturacion Electronica         ");
            ICLogReporteDian = new List<LogReporteDian>();
            LoadICLogReporteDian();
        }
        public void Inicio(DateTime fecini)
        {
            //borrar();
            int Total = ICLogReporteDian.Count;
            int Procesadas = 0;
            if (ICLogReporteDian.Count > 0)
            {
                foreach (var p in ICLogReporteDian)
                {
                    console.CBlack();
                    console.Clear();
                    console.Ih("   APLICATIVO FACTURACION ELECTRONICA CON VALIDACION PREVIA  ver 1.0.2", false);
                    console.Ih("   ========== =========== =========== === ========== ======  *** * * *", false);
                    console.Ihe("Facturas a procesar : " + Total + ". Procesadas : " + Procesadas + ". Pendientes : " + (Total - Procesadas).ToString() + "\r\n");
                    ICollection<InformacionDian> ICInformacionDianpROCESO = new List<InformacionDian>();
                    ICInformacionDianpROCESO = LeerInformacionDian(p.LODI_LLAVE_V2);
                    if (ICInformacionDianpROCESO.Count > 0)
                    {
                        string mensaje = string.Empty;
                        foreach (InformacionDian item in ICInformacionDianpROCESO)
                        {
                            if (item.INDI_CUFEDIAN_V2 == "EN PROCESO")
                            {
                                mensaje = string.Empty;
                                mensaje += "La Factura " + item.INDI_NUMDOC_V2 + " se encuentra en proceso...!!\r\n";
                                mensaje += "\r\n      ==> Informacion de la factura < == \r\n";
                                mensaje += "\r\n Fecha  : " + item.INDI_FECCREA_TS;
                                mensaje += "\r\n Correo : " + item.INDI_EMAIL_V2;
                                mensaje += "\r\n Id     : " + item.INDI_IDCARVAJAL_V2;
                                mensaje += "\r\n Valida : " + item.INDI_VALIDACION_CL;
                                console.Ih(mensaje);
                                SendEmail("Factura en Proceso", mensaje, "fmontoya@transer.com.co", "jefesoporte@transer.com.co", "francisco.montoya.l@gmail.com");
                                //if (p.LODI_LLAVE_V2=="ETCA10039")
                                //{
                                //procesarFactura(p);
                                //}
                                ILogicaInfoFactura Lif = new LogicaInfoFactura(Usuario, Password, UsuEmail, PassEmail, Ambiente);
                                string cufe = string.Empty;
                                cufe = Lif.Inicio(p.LODI_LLAVE_V2);

                                SendEmailFacturaClient sendEmailFacturaClient = new SendEmailFacturaClient(Usuario, Password, UsuEmail, PassEmail, Ambiente);
                                var sendMailClient = sendEmailFacturaClient.SendMailClients(item);

                                break;
                            }
                            else
                            {
                                procesarFactura(p);
                            }
                        }
                    }
                    else
                    {
                        procesarFactura(p);
                    }

                    //procesarFactura(p);
                    Procesadas++;
                    console.Clear();
                }
            }
            else
            {
                //addLog("NO HAY REGISTROS PARA PROCESAR....");
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void borrar()
        {
            ICollection<InformacionDian> ICInformacionDianpROCESO = new List<InformacionDian>();
            ICInformacionDianpROCESO = LeerInformacionDian("EBGT11781");
            if (ICInformacionDianpROCESO.Count > 0)
            {
                string mensaje = string.Empty;
                foreach (InformacionDian item in ICInformacionDianpROCESO)
                {
                    SendEmailFacturaClient sendEmailFacturaClient = new SendEmailFacturaClient(Usuario, Password, UsuEmail, PassEmail, Ambiente);
                    var sendMailClient = sendEmailFacturaClient.SendMailClients(item);

                    break;
                }
            }
        }
    }
}
