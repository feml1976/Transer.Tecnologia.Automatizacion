using System;
namespace Transer.Tecnologia.Automatizacion.EntityMilenio
{
    public class Propietarios
    {

        public double PROP_CEDULA_NB { get; set; } // NOT NULL NUMBER(13)
        public int PROP_NOMBRE_V2 { get; set; } //  NOT NULL VARCHAR2(100)
        public string PROP_APELLIDO_V2 { get; set; } //  VARCHAR2(25)
        public string PROP_DIRECCION_V2 { get; set; } //  NOT NULL VARCHAR2(70)
        public double PROP_TELEFONO_NB { get; set; } //  NOT NULL NUMBER(10)
        public int PROP_CIUDRES_NB { get; set; } //  NOT NULL NUMBER(5)
        public string PROP_CLASE_V2 { get; set; } //  NOT NULL VARCHAR2(1)
        public int PROP_CALIFICA_NB { get; set; } //  NUMBER(3)
        public double PROP_CELULAR_NB { get; set; } //  NUMBER(10)
        public string PROP_TIPO_V2 { get; set; } //  NOT NULL VARCHAR2(1)
        public string PROP_TIPOIDEN_V2 { get; set; } //  NOT NULL VARCHAR2(1)
        public int PROP_BANCO_NB { get; set; } //  NUMBER(5)
        public double PROP_CUENTA_NB { get; set; } //  NUMBER(15)
        public string PROP_TIPOCUENTA_V2 { get; set; } //  VARCHAR2(2)
        public string PROP_ESTADO_V2 { get; set; } //  VARCHAR2(1)
        public DateTime PROP_FECCREA_DT { get; set; } //  DATE
        public double PROP_USUCREA_NB { get; set; } //  NUMBER(13)
        public DateTime PROP_FECANULA_DT { get; set; } //  DATE
        public double PROP_USUANULA_NB { get; set; } //  NUMBER(13)
        public int COND_OFICREA_NB { get; set; } //  NUMBER(3)
        public int PROP_OFIACTUALIZA_NB { get; set; } //  NUMBER(3)

    }
}
