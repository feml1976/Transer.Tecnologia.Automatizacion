using System;

namespace Transer.Tecnologia.Automatizacion.EntityBavaria
{
    public class LogReporteBavaria
    {
        public double REBA_SECUENCIA_NB { get; set; }//NOT NULL NUMBER(13)
        public int REBA_OFICINA_NB { get; set; }//NOT NULL NUMBER(3)
        public int REBA_TRANSACCION_NB { get; set; }//NOT NULL NUMBER(3)
        public string REBA_LLAVE_V2 { get; set; }//NOT NULL VARCHAR2(13)
        public DateTime REBA_FECHA_DT { get; set; }//DATE
        public string REBA_ESTADO_V2 { get; set; }//NOT NULL VARCHAR2(1)
        public double REBA_CAMPO1_NB { get; set; }//NUMBER(13)
        public string REBA_CAMPO2_V2 { get; set; }//VARCHAR2(13)
        public DateTime REBA_CAMPO3_DT { get; set; }//DATE   
    }
}
