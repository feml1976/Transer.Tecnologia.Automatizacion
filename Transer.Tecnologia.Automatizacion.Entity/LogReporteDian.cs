using System;

namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class LogReporteDian
    {
        public double LODI_SECUENCIA_NB { get; set; }// NOT NULL NUMBER(13)
        public int LODI_OFICINA_NB { get; set; }// NOT NULL NUMBER(3)
        public int LODI_TRANSACCION_NB { get; set; }// NOT NULL NUMBER(3)
        public string LODI_LLAVE_V2 { get; set; }// NOT NULL VARCHAR2(13)
        public DateTime? LODI_FECREGISTRO_DT { get; set; }// NOT NULL DATE
        public string LODI_ESTADO_V2 { get; set; }// NOT NULL VARCHAR2(1)
        public double LODI_CAMPO1_NB { get; set; }// NUMBER(13)
        public string LODI_CAMPO2_V2 { get; set; }// VARCHAR2(13)
        public DateTime? LODI_CAMPO3_DT { get; set; }// DATE
        public string LODI_ESTADODIAN_V2 { get; set; }//
    }
}
