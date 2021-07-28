using System;
namespace Transer.Tecnologia.Automatizacion.EntityBavaria
{
    public class DetLogBavaria
    {
        public double DEBA_SECUENCIA_NB { get; set; }// NOT NULL NUMBER(13)
        public double DEBA_LOGBAVARIA_NB { get; set; }// NOT NULL NUMBER(13)
        public int DEBA_OFICINA_NB { get; set; }// NOT NULL NUMBER(3)
        public int DEBA_TRANSACCION_NB { get; set; }// NOT NULL NUMBER(3)
        public string DEBA_LLAVE_V2 { get; set; }// NOT NULL VARCHAR2(13)
        public double DEBA_NUMACEPTA_NB { get; set; }// NUMBER(13)
        public string DEBA_ESTADO_V2 { get; set; }// NOT NULL VARCHAR2(1)
        public string DEBA_SOAPENVIADO_V2 { get; set; }// NOT NULL VARCHAR2(4000)
        public string DEBA_SOAPRECIBIDO_V2 { get; set; }// NOT NULL VARCHAR2(4000)
        public DateTime DEBA_FECPROCESA_DT { get; set; }// NOT NULL DATE
        public double DEBA_CAMPO1_NB { get; set; }// NUMBER(20)
        public DateTime DEBA_CAMPO2_DT { get; set; }// DATE
        public string DEBA_CAMPO3_V2 { get; set; }// VARCHAR2(100)
    }
}
