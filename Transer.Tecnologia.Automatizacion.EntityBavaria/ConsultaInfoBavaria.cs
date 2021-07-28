using System;
namespace Transer.Tecnologia.Automatizacion.EntityBavaria
{
    public class ConsultaInfoBavaria
    {

        public string VIAJ_NOPLANILLA_V2 { get; set; }//manifiesto
        public string OFIC_NOMBRE_V2 { get; set; }//oficina
        public string VIAJ_PLACA_CH { get; set; }//placa
        public string CLVE_DESCRIP_V2 { get; set; }//tipovehiculo
        public string VIAJ_TRAILER_CH { get; set; }//placaremolque
        public DateTime VIAJ_FECVIAJE_DT { get; set; }//fecha
        public int CAMI_KMSTOTAL_NB { get; set; }//distancia
        public string COND_NOMBRE_V2 { get; set; }//nombreconductor
        public double COND_CEDULA_NB { get; set; }//cedula
        public string CIUD_DESCRIPCION_ORIGEN_V2 { get; set; }//origen
        public int CIUD_CODIGO_ORIGEN_NB { get; set; }//codigoorigen
        public string CIUD_DESCRIPCION_DESTINO_V2 { get; set; }//destino
        public int CIUD_CODIGO_DESTINO_NB { get; set; }//codigodestino
        public string DESC_RUTA_V2  { get; set; }//ruta
        public int ORCA_RUTA_NB { get; set; }//codigoruta
        public string PROD_NOMBRE_V2 { get; set; }//tipocarga
        public string GENE_DESCRIPCION_V2 { get; set; }//unidadmercancia

        /*                  FROM VIAJES V, OFICINAS O, CONDUCTORES C, ORDENES_CARGUE O, RUTAS R,
                            CIUDADES CO, CIUDADES CD, VIAJE_DESTINOS VD, CUMPLIDOS M, 
                            PRODUCTOS P, VEHICULOS H, CLASE_VEHICULO CV, CAMINOS CM, GENERICAS EMPAQ
        */
        public string MyProperty { get; set; }
    }
}
