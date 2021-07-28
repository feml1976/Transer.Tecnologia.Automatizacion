using System;
namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class DetLogDian
    {
        public double DELD_SECUENCIA_NB { get; set; }// NOT NULL NUMBER(13)
        public double DELD_LOGSECUENCIA_NB { get; set; }// NOT NULL NUMBER(13)
        public int DELD_OFICINA_NB { get; set; }// NOT NULL NUMBER(3)
        public int DELD_TRANSACCION_NB { get; set; }// NOT NULL NUMBER(3)
        public string DELD_LLAVE_V2 { get; set; }// NOT NULL VARCHAR2(15)
        public string DELD_ESTADO_V2 { get; set; }//NOT NULL VARCHAR2(1)
        public string DELD_IDDIAN_V2 { get; set; }//VARCHAR2(100)
        public string DELD_CUFEDIAN_V2 { get; set; }//VARCHAR2(100)
        public byte[] DELD_SOAPENVIADO_BL { get; set; }//BLOB
        public DateTime? DELD_FECHAENVIO_DT { get; set; }//NOT NULL DATE
        public byte[] DELD_SOAPRECIBIDO_BL { get; set; }//BLOB
        public double DELD_CAMPO1_NB { get; set; }//NUMBER(13)
        public DateTime? DELD_CAMPO2_V2 { get; set; }//DATE
        public string DELD_CAMPO3_DT { get; set; }//VARCHAR2(13)
        public string DELD_ESTADODIAN_V2 { get; set; }//VARCHAR2(1)

    }
}
