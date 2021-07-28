using System;
using System.Collections.Generic;
using System.Xml;
using Transer.Tecnologia.Automatizacion.Entity;
using Transer.Tecnologia.Automatizacion.Infrastructure;

namespace Transer.Tecnologia.Automatizacion.caDStysGetInfoFactura
{
    public partial class LogicaInfoFactura : ILogicaInfoFactura
    {
        /*VERSION PRODUCCION*/
        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }

        public Consola console;
        public LogicaInfoFactura(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            console = new Consola("LogicaInfoFactura");
        }
        public string Inicio(string factura)
        {
            validarDirectorio(factura);
            console.CBlack();
            console.Ih("=> Represantacion Grafica Factura");
            System.Threading.Thread.Sleep(18000);
            HttpsWebRequestsFunction httpwebrequestFunction = new HttpsWebRequestsFunction();
            httpwebrequestFunction = PdfFactura(factura);
            /*validarDirectorio(factura);
            httpwebrequestFunction = Cufe(factura);*/
            return httpwebrequestFunction._cufe;
        }
        public void Inicio()
        {
            ICollection<InformacionDian> ICInformacionDian = new List<InformacionDian>();
            ICInformacionDian = LeerInformacionDianEnProceso();
            if (ICInformacionDian.Count>0)
            {
                foreach (var item in ICInformacionDian)
                {
                    validarDirectorio(item.INDI_NUMDOC_V2);
                    console.Ih("Envío factura: "+item.INDI_NUMDOC_V2 + " Fecha : " + item.INDI_FECCREA_TS + "\r\nValidacion : " + item.INDI_VALIDACION_CL);
                    HttpsWebRequestsFunction httpwebrequestFunction = new HttpsWebRequestsFunction();
                    httpwebrequestFunction = PdfFactura(item.INDI_NUMDOC_V2);
                    //validarDirectorio(item.INDI_NUMDOC_V2);
                    //httpwebrequestFunction = Cufe(item.INDI_NUMDOC_V2);
                }
            }
            else
            {
                //...Falta Implementar
            }
        }
    }
}
