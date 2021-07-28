using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caUrbanosLogicaNegocio
{
    public partial class LogicaNegocio :ILogicaNegocio
    {
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public ICollection<LogReporteMinisterio> ICLogReporteMinisterio { get; set; }
        public List<LogReporteMinisterio> LLogReporteMinisterio { get; set; }
        public Consola console;
        public string ExcepcionEjecucion { get; set; }
        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            //SendEmail("Pruebas", "Mensaje de prueba", "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            //console.Clear();
            //console.CBlack();
            string titulo = "                            MINISTERIO DE TRANSPORTE\r\n" + "                            ========== == ==========\r\n";
            console = new Consola(titulo);
            ICLogReporteMinisterio = new List<LogReporteMinisterio>();
            LoadICLogReporteMinisterio();
            //LLogReporteMinisterio = new List<LogReporteMinisterio>();
            //List<LogReporteMinisterio> entityList = new List<LogReporteMinisterio>(ICLogReporteMinisterio);//.ToList<LogReporteMinisterio>;//.CopyTo(LLogReporteMinisterio[],0);
            LLogReporteMinisterio = new List<LogReporteMinisterio>(ICLogReporteMinisterio);

        }

        public void Inicio(DateTime fecini)
        {
           
        }
    }
}
