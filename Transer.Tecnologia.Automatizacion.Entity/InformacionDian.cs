using System;
namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class InformacionDian
    {
        public string INDI_NUMDOC_V2 { get; set; }// NOT NULL VARCHAR2(15)
        public int INDI_OFICDOC_NB { get; set; }// NOT NULL NUMBER(3)
        public string INDI_TIPODOC_V2 { get; set; }// NOT NULL VARCHAR2(3)
        public string INDI_EMAIL_V2 { get; set; }// VARCHAR2(70)
        public string INDI_XMLENV_CB { get; set; }// CLOB
        public string INDI_CUFEDIAN_V2 { get; set; }// VARCHAR2(128)
        public string INDI_IDCARVAJAL_V2 { get; set; }// VARCHAR2(40)
        public byte[] INDI_XMLREC_BL { get; set; }// BLOB
        public byte[] INDI_REPGRAFICA_BL { get; set; }// BLOB
        public string INDI_XMLLEGAL_CB { get; set; }// CLOB
        public DateTime INDI_FECCREA_TS { get; set; }// TIMESTAMP(6)
        public DateTime INDI_FECESTADO_TS { get; set; }// TIMESTAMP(6)
        public string INDI_VALIDACION_CL { get; set; }// CLOB
        public int INDI_CLIENTE_NB { get; set; }// NUMBER(5)
        public string INDI_NOMCLIENTE_V2 { get; set; }//  VARCHAR2(230)
    }
}
