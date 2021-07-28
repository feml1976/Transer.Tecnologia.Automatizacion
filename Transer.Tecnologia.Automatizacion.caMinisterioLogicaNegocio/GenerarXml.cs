using System;
using System.Data;
using System.Xml.Linq;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;

namespace Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio
{
    public class GenerarXml
    {
        public string ExcepcionEjecucion { get; set; }
        public string procesar_remesa(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "3"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("consecutivoRemesa", drw["consecutivoRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : consecutivoRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codoperaciontransporte", drw["codoperaciontransporte"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codoperaciontransporte\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codNaturalezaCarga", drw["codNaturalezaCarga"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codNaturalezaCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("cantidadCargada", drw["cantidadCargada"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : cantidadCargada\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("unidadMedidaCapacidad", drw["unidadMedidaCapacidad"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : unidadMedidaCapacidad\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoEmpaque", drw["codTipoEmpaque"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoEmpaque\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("mercanciaremesa", drw["mercanciaremesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : mercanciaremesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("descripcionCortaProducto", drw["descripcionCortaProducto"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : descripcionCortaProducto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdRemitente", drw["codTipoIdRemitente"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdRemitente\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdRemitente", drw["numIdRemitente"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdRemitente\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeRemitente", drw["codSedeRemitente"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeRemitente\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdDestinatario", drw["codTipoIdDestinatario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdDestinatario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdDestinatario", drw["numIdDestinatario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdDestinatario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeDestinatario", drw["codSedeDestinatario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeDestinatario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("duenoPoliza", drw["duenoPoliza"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : duenoPoliza\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numPolizaTransporte", drw["numPolizaTransporte"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numPolizaTransporte\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("companiaSeguro", drw["companiaSeguro"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : companiaSeguro\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaVencimientoPolizaCarga", drw["fechaVencimientoPolizaCarga"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaVencimientoPolizaCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horasPactoCarga", drw["horasPactoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horasPactoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("minutosPactoCarga", drw["minutosPactoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : minutosPactoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horasPactoDescargue", drw["horasPactoDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horasPactoDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("minutosPactoDescargue", drw["minutosPactoDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : minutosPactoDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaLlegadaCargue", drw["fechaLlegadaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaLlegadaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaLlegadaCargueRemesa", drw["horaLlegadaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaLlegadaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaEntradaCargue", drw["fechaEntradaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaEntradaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaEntradaCargueRemesa", drw["horaEntradaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaEntradaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaSalidaCargue", drw["fechaSalidaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaSalidaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaSalidaCargueRemesa", drw["horaSalidaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaSalidaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdPropietario", drw["codTipoIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdPropietario", drw["numIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedePropietario", drw["codSedePropietario"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedePropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaCitaPactadaCargue", drw["fechaCitaPactadaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaCitaPactadaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaCitaPactadaCargue", drw["horaCitaPactadaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaCitaPactadaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaCitaPactadaDescargue", drw["fechaCitaPactadaDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaCitaPactadaDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaCitaPactadaDescargueRemesa", drw["horaCitaPactadaDescargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;

                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaCitaPactadaDescargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }
        public string procesar_manifiesto_carga(DataRow drw, string path, int oficina)
        {

            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "4"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numManifiestoCarga", drw["numManifiestoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numManifiestoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codOperacionTransporte", drw["codOperacionTransporte"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codOperacionTransporte\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaExpedicionManifiesto", drw["fechaExpedicionManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaExpedicionManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioOrigenManifiesto", drw["codMunicipioOrigenManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioOrigenManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioDestinoManifiesto", drw["codMunicipioDestinoManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioDestinoManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codIdTitularManifiesto", drw["codIdTitularManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codIdTitularManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTitularManifiesto", drw["numIdTitularManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTitularManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numPlaca", drw["numPlaca"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numPlaca\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["numPlacaRemolque"].ToString() != "")
                {
                    nodoVariables.Add(new XElement("numPlacaRemolque", drw["numPlacaRemolque"].ToString()));//writer.WriteElementString("numPlacaRemolque", drw["numPlacaRemolque"].ToString());
                }
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numPlacaRemolque\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codIdConductor", drw["codIdConductor"].ToString()));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codIdConductor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdconductor", drw["numIdconductor"].ToString()));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdconductor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                string VALORFLETEPACTADOVIAJE = drw["valorFletePactadoViaje"].ToString();
                nodoVariables.Add(new XElement("valorFletePactadoViaje", VALORFLETEPACTADOVIAJE.Replace(",", ".")));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorFletePactadoViaje\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                string retencionFuenteManifiesto = drw["retencionFuenteManifiesto"].ToString();
                nodoVariables.Add(new XElement("retencionFuenteManifiesto", retencionFuenteManifiesto.Replace(",", ".")));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : \r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                string retencionIcaManifiestoCarga = drw["retencionIcaManifiestoCarga"].ToString();
                nodoVariables.Add(new XElement("retencionIcaManifiestoCarga", retencionIcaManifiestoCarga.Replace(",", ".")));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : retencionIcaManifiestoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                string ValorAnticipoManifiesto = drw["ValorAnticipoManifiesto"].ToString();
                nodoVariables.Add(new XElement("ValorAnticipoManifiesto", ValorAnticipoManifiesto.Replace(",", ".")));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : ValorAnticipoManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioPagoSaldo", drw["codMunicipioPagoSaldo"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioPagoSaldo\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaPagoSaldoManifiesto", drw["fechaPagoSaldoManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaPagoSaldoManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codResponsablePagoCargue", drw["codResponsablePagoCargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codResponsablePagoCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codResponsablePagoDescargue", drw["codResponsablePagoDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codResponsablePagoDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["observaciones"].ToString() != "")
                    nodoVariables.Add(new XElement("observaciones", drw["observaciones"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : observaciones\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                XElement nodoREMESASMAN = new XElement("REMESASMAN");
                XAttribute attribute = new XAttribute("procesoid", "43");
                nodoREMESASMAN.Add(attribute);
                XElement nodoREMESA = new XElement("REMESA");
                nodoREMESA.Add(new XElement("consecutivoRemesa", drw["consecutivoRemesa"].ToString()));
                nodoREMESASMAN.Add(nodoREMESA);
                nodoVariables.Add(nodoREMESASMAN);
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : consecutivoRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }


        public string procesar_cumplido_remesa(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "5"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
               // _correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("consecutivoRemesa", drw["consecutivoRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : consecutivoRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numManifiestoCarga", drw["numManifiestoCarga"].ToString()));
            }
            catch (Exception ex)
            {
               //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
               // _correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numManifiestoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("tipoCumplidoRemesa", drw["tipoCumplidoRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : tipoCumplidoRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["motivoSuspensionRemesa"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("motivoSuspensionRemesa", drw["motivoSuspensionRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML motivoSuspensionRemesa\r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoSuspensionRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("cantidadCargada", drw["cantidadCargada"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : cantidadCargada\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("cantidadEntregada", drw["cantidadEntregada"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : cantidadEntregada\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("unidadMedidaCapacidad", drw["unidadMedidaCapacidad"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : unidadMedidaCapacidad\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaLlegadaCargue", drw["fechaLlegadaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaLlegadaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaLlegadaCargueRemesa", drw["horaLlegadaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaLlegadaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaEntradaCargue", drw["fechaEntradaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaEntradaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaEntradaCargueRemesa", drw["horaEntradaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaEntradaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaSalidaCargue", drw["fechaSalidaCargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
               // _correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaSalidaCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaSalidaCargueRemesa", drw["horaSalidaCargueRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaSalidaCargueRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaLlegadaDescargue", drw["fechaLlegadaDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
               // _correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaLlegadaDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaLlegadaDescargueCumplido", drw["horaLlegadaDescargueCumplido"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaLlegadaDescargueCumplido\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaEntradaDescargue", drw["fechaEntradaDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaEntradaDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaEntradaDescargueCumplido", drw["horaEntradaDescargueCumplido"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaEntradaDescargueCumplido\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaSalidaDescargue", drw["fechaSalidaDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaSalidaDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("horaSalidaDescargueCumplido", drw["horaSalidaDescargueCumplido"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : horaSalidaDescargueCumplido\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                if (drw["observaciones"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("observaciones", drw["observaciones"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML observaciones\r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : observaciones\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);

            document.Save(path);
            return document.ToString();
        }


        public string procesar_cumplir_manifiesto(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "6"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numManifiestoCarga", drw["numManifiestoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numManifiestoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("tipoCumplidoManifiesto", drw["tipoCumplidoManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : tipoCumplidoManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaEntregaDocumentos", drw["fechaEntregaDocumentos"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaEntregaDocumentos\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("valorAdicionalHorasCargue", drw["valorAdicionalHorasCargue"].ToString()));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorAdicionalHorasCargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("valorAdicionalHorasDescargue", drw["valorAdicionalHorasDescargue"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorAdicionalHorasDescargue\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("valorAdicionalFlete", drw["valorAdicionalFlete"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorAdicionalFlete\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["motivoValorAdicional"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("motivoValorAdicional", drw["motivoValorAdicional"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoValorAdicional\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("valorDescuentoFlete", drw["valorDescuentoFlete"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorDescuentoFlete\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("motivoValorDescuentoManifiesto", drw["motivoValorDescuentoManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoValorDescuentoManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("valorSobreAnticipo", drw["valorSobreAnticipo"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : valorSobreAnticipo\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);

            document.Save(path);
            return document.ToString();
        }

        public string procesar_propietarios_nit(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "11"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");
            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                ExcepcionEjecucion = ex.Message;
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                //nodoVariables.Add(new XElement("TERNITEMPRESA", drw["TERNITEMPRESA"].ToString()));
                nodoVariables.Add(new XElement("codTipoIdTercero", drw["codTipoIdTercero"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERNITEMPRESA\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                //nodoVariables.Add(new XElement("TERTIPOID", drw["TERTIPOID"].ToString()));
                nodoVariables.Add(new XElement("numIdTercero", drw["numIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERTIPOID\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                //nodoVariables.Add(new XElement("TERTIPOID", drw["TERTIPOID"].ToString()));
                nodoVariables.Add(new XElement("nomIdTercero", drw["nomIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERTIPOID\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("primerApellidoIdTercero", drw["primerApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                nodoVariables.Add(new XElement("primerApellidoIdTercero", "  "));
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERTELEFONO\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("segundoApellidoIdTercero", drw["segundoApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                nodoVariables.Add(new XElement("segundoApellidoIdTercero", " "));
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERDIRECCION\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                string tele = drw["numTelefonoContacto"].ToString();
                if (tele.Length>7)
                {
                    nodoVariables.Add(new XElement("numTelefonoContacto", tele.Substring(1, 7)));
                }
                else
                {
                    nodoVariables.Add(new XElement("numTelefonoContacto", drw["numTelefonoContacto"].ToString()));
                }                               
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERCIUDAD\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomenclaturaDireccion", drw["nomenclaturaDireccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERSEDE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioRndc", drw["codMunicipioRndc"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERSEDE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeTercero", drw["codSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERSEDE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomSedeTercero", drw["nomSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : TERSEDENOMBRE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }

        public string procesar_propietarios_cedula(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "11"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("codTipoIdTercero", drw["codTipoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : \r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTercero", drw["numIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomIdTercero", drw["nomIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("primerApellidoIdTercero", drw["primerApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : primerApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["segundoApellidoIdTercero"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("segundoApellidoIdTercero", drw["segundoApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : segundoApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeTercero", drw["codSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomSedeTercero", drw["nomSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomenclaturaDireccion", drw["nomenclaturaDireccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomenclaturaDireccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioRndc", drw["codMunicipioRndc"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioRndc\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }

        public string procesar_clientes_nit(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "11"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("codTipoIdTercero", drw["codTipoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTercero", drw["numIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomIdTercero", drw["nomIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeTercero", drw["codSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomSedeTercero", drw["nomSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomenclaturaDireccion", drw["nomenclaturaDireccion"].ToString()));
            }
            catch (Exception ex)
            {
               // _pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomenclaturaDireccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioRndc", drw["codMunicipioRndc"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioRndc\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("LATITUD", drw["LATITUD"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : LATITUD\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("LONGITUD", drw["LONGITUD"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
               // _correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : LONGITUD\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }

        public string procesar_clientes_cedula(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "11"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("codTipoIdTercero", drw["codTipoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTercero", drw["numIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomIdTercero", drw["nomIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("primerApellidoIdTercero", drw["primerApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : primerApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["segundoApellidoIdTercero"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("segundoApellidoIdTercero", drw["segundoApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : segundoApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeTercero", drw["codSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomSedeTercero", drw["nomSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomenclaturaDireccion", drw["nomenclaturaDireccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomenclaturaDireccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioRndc", drw["codMunicipioRndc"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioRndc\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("LATITUD", drw["LATITUD"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : LATITUD\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("LONGITUD", drw["LONGITUD"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : LONGITUD\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }

        public string procesar_conductores(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "11"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("codTipoIdTercero", drw["codTipoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTercero", drw["numIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomIdTercero", drw["nomIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("primerApellidoIdTercero", drw["primerApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : primerApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                if (drw["segundoApellidoIdTercero"].ToString().Length > 0)
                    nodoVariables.Add(new XElement("segundoApellidoIdTercero", drw["segundoApellidoIdTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : segundoApellidoIdTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codSedeTercero", drw["codSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomSedeTercero", drw["nomSedeTercero"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomSedeTercero\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("nomenclaturaDireccion", drw["nomenclaturaDireccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : nomenclaturaDireccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMunicipioRndc", drw["codMunicipioRndc"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMunicipioRndc\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codCategoriaLicenciaConduccion", drw["codCategoriaLicenciaConduccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codCategoriaLicenciaConduccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numLicenciaConduccion", drw["numLicenciaConduccion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numLicenciaConduccion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaVencimientoLicencia", drw["fechaVencimientoLicencia"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaVencimientoLicencia\r\n Descripcion del Error : " + ex.Message, _vgp);
            }


            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }


        public string procesar_vehiculos(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "12"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numPlaca", drw["numPlaca"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numPlaca\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codConfiguracionUnidadCarga", drw["codConfiguracionUnidadCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codConfiguracionUnidadCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMarcaVehiculoCarga", drw["codMarcaVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMarcaVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codLineaVehiculoCarga", drw["codLineaVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codLineaVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numEjes", drw["numEjes"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numEjes\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("anoFabricacionVehiculoCarga", drw["anoFabricacionVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : anoFabricacionVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("anoRepotenciacion", drw["anoRepotenciacion"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : anoRepotenciacion\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codColorVehiculoCarga", drw["codColorVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codColorVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("pesoVehiculoVacio", drw["pesoVehiculoVacio"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : pesoVehiculoVacio\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("capacidadUnidadCarga", drw["capacidadUnidadCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : capacidadUnidadCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("unidadMedidaCapacidad", drw["unidadMedidaCapacidad"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : unidadMedidaCapacidad\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoCarroceria", drw["codTipoCarroceria"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoCarroceria\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numChasis", drw["numChasis"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numChasis\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoCombustible", drw["codTipoCombustible"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoCombustible\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numSeguroSoat", drw["numSeguroSoat"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numSeguroSoat\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("fechaVencimientoSoat", drw["fechaVencimientoSoat"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : fechaVencimientoSoat\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numNitAseguradoraSoat", drw["numNitAseguradoraSoat"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numNitAseguradoraSoat\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdPropietario", drw["codTipoIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdPropietario", drw["numIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdTenedor", drw["codTipoIdTenedor"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdTenedor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTenedor", drw["numIdTenedor"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTenedor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();
        }

        public string procesar_trailers(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "12"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numPlaca", drw["numPlaca"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numPlaca\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codConfiguracionUnidadCarga", drw["codConfiguracionUnidadCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codConfiguracionUnidadCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codMarcaVehiculoCarga", drw["codMarcaVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codMarcaVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("anoFabricacionVehiculoCarga", drw["anoFabricacionVehiculoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : anoFabricacionVehiculoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("pesoVehiculoVacio", drw["pesoVehiculoVacio"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : pesoVehiculoVacio\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoCarroceria", drw["codTipoCarroceria"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoCarroceria\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdPropietario", drw["codTipoIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdPropietario", drw["numIdPropietario"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdPropietario\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("codTipoIdTenedor", drw["codTipoIdTenedor"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : codTipoIdTenedor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("numIdTenedor", drw["numIdTenedor"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numIdTenedor\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);

            document.Save(path);

            return document.ToString();
        }

        public string procesar_anular_remesa(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "9"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("motivoReversaRemesa", drw["motivoReversaRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoReversaRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("motivoAnulacionRemesa", drw["motivoAnulacionRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoAnulacionRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("consecutivoRemesa", drw["consecutivoRemesa"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message, tRed, clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : consecutivoRemesa\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);
            document.Save(path);
            return document.ToString();

        }

        public string procesar_anular_manifiesto(DataRow drw, string path, int oficina)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");

            #region Definicion del nodo acceso

            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));

            #endregion fin de la Definicion del nodo acceso

            nodoRoot.Add(nodoAcceso);

            #region Definicion del nodo Solicitud

            XElement nodoSolicitud = new XElement("solicitud");
            nodoSolicitud.Add(new XElement("tipo", "1"));
            nodoSolicitud.Add(new XElement("procesoid", "32"));

            #endregion fin de la Definicion del nodo Solicitud

            nodoRoot.Add(nodoSolicitud);

            #region Definicion del nodo Variables

            XElement nodoVariables = new XElement("variables");

            try
            {
                nodoVariables.Add(new XElement("NUMNITEMPRESATRANSPORTE", drw["numNitEmpresaTransporte"].ToString()));

            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : NUMNITEMPRESATRANSPORTE\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("numManifiestoCarga", drw["numManifiestoCarga"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : numManifiestoCarga\r\n Descripcion del Error : " + ex.Message, _vgp);
            }
            try
            {
                nodoVariables.Add(new XElement("motivoAnulacionManifiesto", drw["motivoAnulacionManifiesto"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : motivoAnulacionManifiesto\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            try
            {
                nodoVariables.Add(new XElement("observaciones", drw["observaciones"].ToString()));
            }
            catch (Exception ex)
            {
                //_pantalla.mensajeBlackRed("Se presento un error al momento de construir el Objeto XML \r\nDetalle del Error:\r\n" + ex.Message,tRed,clean);
                //_correo.envioCorreoBaseDatos("Se presento un error al momento de construir el objeto XML", "Nombre del Campo : observaciones\r\n Descripcion del Error : " + ex.Message, _vgp);
            }

            #endregion fin de la Definicion del nodo Variables

            nodoRoot.Add(nodoVariables);

            document.Add(nodoRoot);

            document.Save(path);

            return document.ToString();
        }
        public string maquetarXMLError(string xml_recibido, int ncodigo, string nestado, LogReporteMinisterio p)
        {
            string mensaje = @"Se presento un error al momento de consumir el Web Services del Ministerio.";
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");
            #region Definicion del nodo nodoVariables
            XElement nodoVariables = new XElement("ErrorTYS");
            nodoVariables.Add(new XElement("Error", "TYS001"));
            nodoVariables.Add(new XElement("CodigoError", ncodigo));
            nodoVariables.Add(new XElement("EstadoRegistro", nestado));
            nodoVariables.Add(new XElement("Mensaje", mensaje));
            nodoVariables.Add(new XElement("DetalleError", xml_recibido));
            nodoVariables.Add(new XElement("Secuencia", p.LRMI_SECUENCIA_NB));
            nodoVariables.Add(new XElement("Oficina", p.LRMI_OFICINA_NB));
            nodoVariables.Add(new XElement("Transaccion", p.LRMI_TRANSACCION_NB));
            nodoVariables.Add(new XElement("Llave", p.LRMI_LLAVE_V2));
            nodoVariables.Add(new XElement("Fecha", p.LRMI_FECREGISTRO_DT));
            nodoVariables.Add(new XElement("Estado", p.LRMI_ESTADO_V2));
            nodoVariables.Add(new XElement("Campo1", p.LRMI_CAMPO1_NB));
            nodoRoot.Add(nodoVariables);
            #endregion fin de la Definicion del nodo nodoVariables
            document.Add(nodoRoot);
            return document.ToString();

        }
        public string SelectSinValores(string v, LogReporteMinisterio p)
        {
            string mensaje = @"No se obtuvo valores de la consulta : " + v + " para el parametro llave = " + p.LRMI_LLAVE_V2;
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");
            #region Definicion del nodo acceso
            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));
            nodoRoot.Add(nodoAcceso);
            #endregion fin de la Definicion del nodo acceso
            #region Definicion del nodo solicitud
            XElement nodosolicitud = new XElement("solicitud");
            nodosolicitud.Add(new XElement("tipo", "1"));
            nodosolicitud.Add(new XElement("procesoid", p.LRMI_TRANSACCION_NB));
            nodoRoot.Add(nodosolicitud);
            #endregion fin de la Definicion del nodo solicitud
            #region Definicion del nodo nodoVariables
            XElement nodoVariables = new XElement("variables");
            nodoVariables.Add(new XElement("Mensaje", mensaje));
            nodoVariables.Add(new XElement("Secuencia", p.LRMI_SECUENCIA_NB));
            nodoVariables.Add(new XElement("Oficina", p.LRMI_OFICINA_NB));
            nodoVariables.Add(new XElement("Transaccion", p.LRMI_TRANSACCION_NB));
            nodoVariables.Add(new XElement("Llave", p.LRMI_LLAVE_V2));
            nodoVariables.Add(new XElement("Fecha", p.LRMI_FECREGISTRO_DT));
            nodoVariables.Add(new XElement("Estado", p.LRMI_ESTADO_V2));
            nodoVariables.Add(new XElement("Campo1", p.LRMI_CAMPO1_NB));
            nodoRoot.Add(nodoVariables);
            #endregion fin de la Definicion del nodo nodoVariables
            document.Add(nodoRoot);
            return document.ToString();
        }
        public string ReturnSinValores(string v, int ncodigo, string nestado, LogReporteMinisterio p)
        {
            string mensaje = @"No se realiza consulta ante el Ministerio por no existir informacion para reportar. El procedimiento almacenado " + v + "  No devolvio valores";
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");
            #region Definicion del nodo nodoVariables
            XElement nodoVariables = new XElement("ErrorTYS");
            nodoVariables.Add(new XElement("Error", "TYS001"));
            nodoVariables.Add(new XElement("CodigoError", ncodigo));
            nodoVariables.Add(new XElement("EstadoRegistro", nestado));
            nodoVariables.Add(new XElement("Mensaje", mensaje));
            nodoVariables.Add(new XElement("Secuencia", p.LRMI_SECUENCIA_NB));
            nodoVariables.Add(new XElement("Oficina", p.LRMI_OFICINA_NB));
            nodoVariables.Add(new XElement("Transaccion", p.LRMI_TRANSACCION_NB));
            nodoVariables.Add(new XElement("Llave", p.LRMI_LLAVE_V2));
            nodoVariables.Add(new XElement("Fecha", p.LRMI_FECREGISTRO_DT));
            nodoVariables.Add(new XElement("Estado", p.LRMI_ESTADO_V2));
            nodoVariables.Add(new XElement("Campo1", p.LRMI_CAMPO1_NB));
            nodoRoot.Add(nodoVariables);
            #endregion fin de la Definicion del nodo nodoVariables
            document.Add(nodoRoot);
            return document.ToString();
        }
        public  string getXmlRecibidoFletx(string xml_recibido, LogReporteMinisterio p)
        {
            string mensaje = @"La plataforma FLETX se encarga del envío de la transaccion.";
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");
            #region Definicion del nodo acceso
            XElement nodoAcceso = new XElement("acceso");
            nodoAcceso.Add(new XElement("username", "TYSROBOT@0764"));
            nodoAcceso.Add(new XElement("password", "TYS8605"));
            nodoAcceso.Add(new XElement("simulacion", "S"));
            nodoRoot.Add(nodoAcceso);
            #endregion fin de la Definicion del nodo acceso
            #region Definicion del nodo solicitud
            XElement nodosolicitud = new XElement("solicitud");
            nodosolicitud.Add(new XElement("tipo", "1"));
            nodosolicitud.Add(new XElement("procesoid", p.LRMI_TRANSACCION_NB));
            nodoRoot.Add(nodosolicitud);
            #endregion fin de la Definicion del nodo solicitud
            #region Definicion del nodo nodoVariables
            XElement nodoVariables = new XElement("variables");
            nodoVariables.Add(new XElement("Mensaje", mensaje));
            nodoVariables.Add(new XElement("Secuencia", p.LRMI_SECUENCIA_NB));
            nodoVariables.Add(new XElement("Oficina", p.LRMI_OFICINA_NB));
            nodoVariables.Add(new XElement("Transaccion", p.LRMI_TRANSACCION_NB));
            nodoVariables.Add(new XElement("Llave", p.LRMI_LLAVE_V2));
            nodoVariables.Add(new XElement("Fecha", p.LRMI_FECREGISTRO_DT));
            nodoVariables.Add(new XElement("Estado", p.LRMI_ESTADO_V2));
            nodoVariables.Add(new XElement("Campo1", p.LRMI_CAMPO1_NB));
            nodoRoot.Add(nodoVariables);
            #endregion fin de la Definicion del nodo nodoVariables
            document.Add(nodoRoot);
            return document.ToString();
        }

        public string getXmlEnvioFletx(string xml_envio, LogReporteMinisterio p)
        {
            string mensaje = @"No se realiza envio ante el Ministerio por que  esta transaccion debe ser enviada desde la plataforma FLETX.";
            XDocument document = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            XElement nodoRoot = new XElement("root");
            #region Definicion del nodo nodoVariables
            XElement nodoVariables = new XElement("ErrorTYS");
            nodoVariables.Add(new XElement("Error", "TYS00"));
            nodoVariables.Add(new XElement("CodigoError", -4));
            nodoVariables.Add(new XElement("EstadoRegistro", "F"));
            nodoVariables.Add(new XElement("Mensaje", mensaje));
            nodoVariables.Add(new XElement("Secuencia", p.LRMI_SECUENCIA_NB));
            nodoVariables.Add(new XElement("Oficina", p.LRMI_OFICINA_NB));
            nodoVariables.Add(new XElement("Transaccion", p.LRMI_TRANSACCION_NB));
            nodoVariables.Add(new XElement("Llave", p.LRMI_LLAVE_V2));
            nodoVariables.Add(new XElement("Fecha", p.LRMI_FECREGISTRO_DT));
            nodoVariables.Add(new XElement("Estado", p.LRMI_ESTADO_V2));
            nodoVariables.Add(new XElement("Campo1", p.LRMI_CAMPO1_NB));
            nodoRoot.Add(nodoVariables);
            #endregion fin de la Definicion del nodo nodoVariables
            document.Add(nodoRoot);
            return document.ToString();

        }
    }
}
