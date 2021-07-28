using System;
namespace Transer.Tecnologia.Automatizacion.EntityMinisterio
{
    public class DetLogMinisterio
    {

        public double DELM_SECUENCIA_NB { get; set; } //NOT NULL NUMBER(13)
        public double DELM_LOGSECUENCIA_NB { get; set; } // NOT NULL NUMBER(13)
        public int DELM_OFICINA_NB { get; set; } // NOT NULL NUMBER(3)
        public int DELM_TRANSACCION_NB { get; set; } // NOT NULL NUMBER(3)
        public string DELM_LLAVE_V2 { get; set; } // NOT NULL VARCHAR2(13)
        public string DELM_ESTADO_V2 { get; set; } // NOT NULL VARCHAR2(1)
        public double DELM_IDMINISTERIO_NB { get; set; } // NUMBER(13)
        public string DELM_XMLENVIADO_XML { get; set; } // NOT NULL XMLTYPE()
        public DateTime DELM_FECENVIO_DT { get; set; } // NOT NULL DATE
        public string DELM_XMLRECIBIDO_XML { get; set; } // XMLTYPE()
        public double DELM_CAMPO1_NB { get; set; } // NUMBER(13)
        public string DELM_CAMPO2_V2 { get; set; } // VARCHAR2(13)
        public DateTime DELM_CAMPO3_DT { get; set; } // DATE
    }
}
