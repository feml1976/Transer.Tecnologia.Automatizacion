using System;
using System.Collections.Generic;
using Transer.Tecnologia.Automatizacion.EntityBavaria;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caWsTysBavariaLogicaNegocio
{
    public partial class LogicaNegocio: ILogicaNegocio
    {
        //public LogReporteBavaria logReporteBavaria  { get; set; }
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public ICollection<LogReporteBavaria> ICLogReporteBavaria { get; set; }
        public ICollection<ConsultaInfoBavaria> ICConsultaInfoBavaria { get; set; }

        public Consola console;

        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail,string ambiente)
        {
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            console = new Consola("        Facturacion Electronica         ");
            ICLogReporteBavaria = new List<LogReporteBavaria>();
            LoadICLogReporteBavaria();

        }
        public void Inicio(DateTime fecini)
        {
            int Total = ICLogReporteBavaria.Count;
            int Procesadas = 0;
            if (ICLogReporteBavaria.Count > 0)
            {
                foreach (var p in ICLogReporteBavaria)
                {
                    console.CBlack();
                    console.Clear();
                    console.Ih("Planilla a procesar : " + Total + ". Procesadas : " + Procesadas + ". Pendientes : " + (Total - Procesadas).ToString() + "\r\n");
                    console.Ih("Info Planilla : " + p.REBA_LLAVE_V2 + "  Fecha Planilla : " + p.REBA_FECHA_DT + "\r\n");
                    procesarDespacho(p);
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
