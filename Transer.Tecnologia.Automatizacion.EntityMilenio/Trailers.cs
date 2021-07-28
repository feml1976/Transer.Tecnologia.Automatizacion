using System;
namespace Transer.Tecnologia.Automatizacion.EntityMilenio
{
    public class Trailers
    {
        public string TRAI_PLACA_CH { get; set; } //         NOT NULL CHAR(6)      
        public int TRAI_TIPO_NB { get; set; } //          NOT NULL NUMBER(5)    
        public int TRAI_MARCA_V2 { get; set; } //         NOT NULL NUMBER(5)    
        public int TRAI_MODELO_NB { get; set; } //        NOT NULL NUMBER(4)    
        public string TRAI_SERIE_NB { get; set; } //                  VARCHAR2(15) 
        public double TRAI_PROPIET_NB { get; set; } //       NOT NULL NUMBER(13)   
        public int TRAI_CATEGORIA_NB { get; set; } //     NOT NULL NUMBER(1)    
        public int TRAI_NACION_NB { get; set; } //        NOT NULL NUMBER(5)    
        public int TRAI_NOEJES_NB { get; set; } //        NOT NULL NUMBER(3)    
        public int TRAI_CAPACIDAD_NB { get; set; } //     NOT NULL NUMBER(3)    
        public int TRAI_TIPOPROPIETA_NB { get; set; } //           NUMBER(1)    
        public string TRAI_ESTADO_V2 { get; set; } //        NOT NULL VARCHAR2(1)  
        public DateTime TRAI_FECCREA_DT { get; set; } //                DATE         
        public double TRAI_USUCREA_NB { get; set; } //                NUMBER(13)   
        public DateTime TRAI_FECANULA_DT { get; set; } //               DATE         
        public double TRAI_USUANULA_NB { get; set; } //               NUMBER(13)   
        public int TRAI_OFICREA_NB { get; set; } //                NUMBER(3)    
        public int TRAI_OFIACTUALIZA_NB { get; set; } //           NUMBER(3)    
        public double TRAI_PESO_NB { get; set; } //                   NUMBER(10)   
        public double TRAI_CAMPO1_NB { get; set; } //                 NUMBER(15)   
        public string TRAI_CAMPO2_V2 { get; set; } //                 VARCHAR2(50) 

    }
}
