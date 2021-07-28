using System;
using System.Collections.Generic;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caFEVOperativoLogicaNegocio
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
            console = new Consola("        Facturacion Electronica Operativo        ");
            ICLogReporteDian = new List<LogReporteDian>();
            LoadICLogReporteDian();
        }


        public void Inicio(DateTime fecini)
        {
            int Total = ICLogReporteDian.Count;
            int Procesadas = 0;
            if (ICLogReporteDian.Count > 0)
            {
                foreach (var p in ICLogReporteDian)
                {
                    console.CBlack();
                    console.Clear();
                    console.Ih("Facturas a procesar : " + Total + ". Procesadas : " + Procesadas + ". Pendientes : " + (Total - Procesadas).ToString() + "\r\n");
                    procesarFactura(p);
                    Procesadas++;
                    console.Clear();
                }
            }
            else
            {
                addLog("if (ICLogReporteDian.Count > 0) NO HAY REGISTROS PARA PROCESAR....");
            }
        }
    }
}
