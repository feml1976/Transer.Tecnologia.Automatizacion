using System;

namespace Transer.Tecnologia.Automatizacion.EntityMinisterio
{
    public class LogReporteMinisterio
    {

        public double LRMI_SECUENCIA_NB { get; set; } // NOT NULL NUMBER(13)
        public int LRMI_OFICINA_NB { get; set; } // NOT NULL NUMBER(3)
        public int LRMI_TRANSACCION_NB { get; set; } // NOT NULL NUMBER(3)
        public string LRMI_LLAVE_V2 { get; set; } // NOT NULL VARCHAR2(13)
        public DateTime LRMI_FECREGISTRO_DT { get; set; } // NOT NULL DATE
        public string LRMI_ESTADO_V2 { get; set; } //NOT NULL VARCHAR2(1)
        public double LRMI_CAMPO1_NB { get; set; } //NUMBER(13)
        public string LRMI_CAMPO2_V2 { get; set; } //VARCHAR2(13)
        public DateTime LRMI_CAMPO3_DT { get; set; } //DATE

    }
}
