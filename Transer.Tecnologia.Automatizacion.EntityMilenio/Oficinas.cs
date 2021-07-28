using System;
namespace Transer.Tecnologia.Automatizacion.EntityMilenio
{
    public class Oficinas
    {
        public int OFIC_CODDPTO_NB { get; set; }// NOT NULL NUMBER(3)
        public int OFIC_CODOFIC_NB { get; set; }// NOT NULL NUMBER(3)
        public string OFIC_NOMBRE_V2 { get; set; }// NOT NULL VARCHAR2(20)
        public int OFIC_CIUDAD_NB { get; set; }// NOT NULL NUMBER(5)
        public string OFIC_DIRECCION_V2 { get; set; }// NOT NULL VARCHAR2(70)
        public double OFIC_TELEFONO_1_NB { get; set; }// NOT NULL NUMBER(10)
        public double OFIC_TELEFONO_2_NB { get; set; }// NUMBER(10)
        public double OFIC_INDICATIVO_NB { get; set; }// NOT NULL NUMBER(8)
        public int OFIC_CENCOST_NB { get; set; }// NOT NULL NUMBER(2)
        public double OFIC_ADMIN_NB { get; set; }// NOT NULL NUMBER(13)
        public string OFIC_EMAIL_V2 { get; set; }// VARCHAR2(50)
        public int OFIC_EMPRESA_NB { get; set; }// NUMBER(5)
        public int OFIC_GERENCIA_NB { get; set; }// NUMBER(5)
    }
}
