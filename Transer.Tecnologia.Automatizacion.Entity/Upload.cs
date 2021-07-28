using System;
namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class Upload
    {
        public int UPLO_SECUENCIA_NB { get; set; } // NOT NULL NUMBER(9)
        public DateTime? UPLO_FECHAENVIO_TS { get; set; } // TIMESTAMP(6)
        public string UPLO_FILENAME_V2 { get; set; } // VARCHAR2(30)
        public byte[] UPLO_FILEDATA_BL { get; set; } // BLOB
        public string UPLO_COMPANYID_V2 { get; set; } // VARCHAR2(30)
        public string UPLO_ACCOUNTID_V2 { get; set; } // VARCHAR2(30)
        public string UPLO_STATUS_V2 { get; set; } // VARCHAR2(2500)
        public string UPLO_TRANSACTIONID_V2 { get; set; } // VARCHAR2(250)
        public byte[] UPLO_XMLFACTURA_BL { get; set; } // BLOB
        public byte[] UPLO_SOAPENVIADO_BL { get; set; } // BLOB
        public byte[] UPLO_SOAPRESPUESTA_BL { get; set; } // BLOB

    }
}
