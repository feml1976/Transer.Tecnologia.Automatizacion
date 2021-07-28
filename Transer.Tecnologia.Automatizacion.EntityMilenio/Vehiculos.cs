using System;
namespace Transer.Tecnologia.Automatizacion.EntityMilenio
{
    public class Vehiculos
    {
        public string VEHI_PLACA_CH { get; set; } // NOT NULL CHAR(6)
        public int VEHI_CLASE_NB { get; set; } // NOT NULL NUMBER(3)
        public int VEHI_MARCA_V2 { get; set; } // NOT NULL NUMBER(5)
        public int VEHI_MODELO_V2 { get; set; } // NOT NULL NUMBER(4)
        public int VEHI_CAPACIDAD_NB { get; set; } // NOT NULL NUMBER(7)
        public string VEHI_NOMOTOR_NB { get; set; } // NOT NULL VARCHAR2(30)
        public int VEHI_NOEJES_NB { get; set; } // NOT NULL NUMBER(3)
        public int VEHI_COLOR_V2 { get; set; } // NOT NULL NUMBER(5)
        public string VEHI_CHASIS_NB { get; set; } // NOT NULL VARCHAR2(30)
        public int VEHI_CONSUMO_NB { get; set; } // NUMBER(7)
        public int VEHI_PROPIETARIO_NB { get; set; } //  NOT NULL NUMBER(1)
        public int VEHI_NACION_NB { get; set; } //  NOT NULL NUMBER(5)
        public double VEHI_EMPAFIL_NB { get; set; } //  NUMBER(9)
        public int VEHI_ESTADO_NB { get; set; } //  NOT NULL NUMBER(5)
        public int VEHI_AFILIADO_NB { get; set; } //  NOT NULL NUMBER(5)
        public int VEHI_VINCULA_NB { get; set; } //  NOT NULL NUMBER(5)
        public string VEHI_ESTADO_V2 { get; set; } //  NOT NULL VARCHAR2(1)
        public int VEHI_MODELOREPO_NB { get; set; } //   { get; set; } //  NUMBER(4)
        public int VEHI_LINEA_NB { get; set; } //  NOT NULL NUMBER(5)
        public int VEHI_TIPOCARRO_NB { get; set; } //  NUMBER(5)
        public string VEHI_NOSERIE_V2 { get; set; } //  NOT NULL VARCHAR2(20)
        public string VEHI_CONFIGURACION_V2 { get; set; } //  NOT NULL VARCHAR2(10)
        public decimal VEHI_PESOVACIO_NB { get; set; } //  NOT NULL NUMBER(12,2)
        public DateTime VEHI_FECCREA_DT { get; set; } //  DATE
        public int VEHI_USUCREA_NB { get; set; } //  NUMBER(13)
        public DateTime VEHI_FECANULA_DT { get; set; } //  DATE
        public int VEHI_USUANULA_NB { get; set; } //  NUMBER(13)
        public int VEHI_OFICREA_NB { get; set; } //  NUMBER(3)
        public int VEHI_OFIACTUALIZA_NB { get; set; } //  NUMBER(3)
    }
}
