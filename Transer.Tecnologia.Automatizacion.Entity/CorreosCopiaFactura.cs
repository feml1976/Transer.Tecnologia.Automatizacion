using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class CorreosCopiaFactura
    {
        public int MyProperty { get; set; }//
        public double COCF_SECUENCIA_NB { get; set; }// NOT NULL NUMBER
        public int COCF_CLIENTE_NB { get; set; }// NUMBER(5)
        public string COCF_EMAIL_V2 { get; set; }// VARCHAR2(100)
        public string COCF_ESTADO_V2 { get; set; }// VARCHAR2(2)
        public DateTime COCF_FECCREA_DT { get; set; }// DATE
        public double COCF_USUCREA_NB { get; set; }// NUMBER(13)
        public double COCF_USUANULA_NB { get; set; }// NUMBER(13)
        public DateTime COCF_FECANULA_DT { get; set; }// DATE        
    }
}
