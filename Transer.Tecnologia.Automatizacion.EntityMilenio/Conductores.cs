using System;

namespace Transer.Tecnologia.Automatizacion.EntityMilenio
{
    public class Conductores
    {
        public double COND_CEDULA_NB { get; set; }  // NOT NULL NUMBER(13)
        public string COND_NOMBRE_V2 { get; set; }  // NOT NULL VARCHAR2(20)
        public string COND_APELLIDO_V2 { get; set; }  // NOT NULL VARCHAR2(20)
        public string COND_DIRECCION_V2 { get; set; }  // NOT NULL VARCHAR2(70)
        public double COND_TELEFONO_NB { get; set; }  // NOT NULL NUMBER(10)
        public int COND_CIUDAD_NB { get; set; }  // NOT NULL NUMBER(5)
        public string COND_NOLICEN_NB { get; set; }  // NOT NULL VARCHAR2(20)
        public int COND_LUGEXP_NB { get; set; }  // NOT NULL NUMBER(5)
        public DateTime COND_FECVENTO_DT { get; set; }  // NOT NULL DATE
        public int COND_CATEG_ { get; set; }  // NOT NULL NUMBER(2)
        public string COND_TIPAFIL_V2 { get; set; }  // NOT NULL VARCHAR2(1)
        public double COND_LIBTRIPTER_NB { get; set; }  // NUMBER(9)
        public int COND_CALIFICACION_NB { get; set; }  // NUMBER(3)
        public string COND_ESTADO_V2 { get; set; }  // NOT NULL VARCHAR2(1)
        public string COND_AJUSTESRE_V2 { get; set; }  // NOT NULL VARCHAR2(1)
        public DateTime COND_FECINIAJUSTE_DT { get; set; }  // DATE
        public string COND_TIPOIDEN_V2 { get; set; }  // NOT NULL VARCHAR2(1)
        public string COND_CLAVEUNO_V2 { get; set; }  // VARCHAR2(20)
        public string COND_CLAVEDOS_V2 { get; set; }  // VARCHAR2(20)
        public int COND_OFICREA_NB { get; set; }  // NUMBER(3)
        public int COND_OFIACTUALIZA_NB { get; set; }  // NUMBER(3)
        public DateTime COND_FECCREA_DT { get; set; }  // DATE
        public double COND_USUCREA_NB { get; set; }  // NUMBER(13)
        public DateTime COND_FECANULA_DT { get; set; }  // DATE
        public double COND_USUANULA_NB { get; set; }  // NUMBER(13)
        public string COND_CATEGORIA_V2 { get; set; }  // VARCHAR2(2)
        public double COND_CAMPO1_NB { get; set; }  // NUMBER(10)
        public string COND_CAMPO2_V2 { get; set; }  // VARCHAR2(20)
        public DateTime COND_CAMPO3_DT { get; set; }  // DATE

    }
}
