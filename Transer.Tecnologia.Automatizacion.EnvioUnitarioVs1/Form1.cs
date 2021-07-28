using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;
namespace Transer.Tecnologia.Automatizacion.EnvioUnitarioVs1
{
    public partial class Form1 : Form
    {
        public int IdTX { get; set; }
        public string rutaArchivo { get; set; }
        public string xml_envio { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ambiente { get; set; }
        public LogReporteMinisterio _logReporteMinisterio { get; set; }
        public List<LogReporteMinisterio> LLogReporteMinisterio { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Usuario = "Zm1vbnRveWE=";
            Password = "ZjkzNWNqbTkyNjI=";
            Ambiente = "cHJvZHVjY2lvbg==";
            rutaArchivo = @"c:\transer\ws\web_ministerio\ttx.xml";
            cbxTransacciones.ValueMember = "Id";
            cbxTransacciones.DisplayMember = "Tx";
            LLogReporteMinisterio = new List<LogReporteMinisterio>();
            cbxTransacciones.DataSource = getTransacciones();
            cbxTransacciones.SelectedIndex = cbxTransacciones.FindStringExact("Trailers");
        }

        private LogReporteMinisterio getLogReporteMinisterio()
        {
            LogReporteMinisterio lgReporteMinisterio = new LogReporteMinisterio();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_LLAVE", ":LRMI_TRANSACCION" };
            _vParametros = new object[2] { txbLlave.Text, IdTX };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                var dt = data.getTable("getLogReporteMinisterioEnvioUnitario", _nParametros, _vParametros);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lgReporteMinisterio = addLogReporteMinisterio(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteMinisterio = data.getTable(\"getLogReporteMinisterio\", _nParametros, _vParametros);");
            }
            return lgReporteMinisterio;
        }
        private LogReporteMinisterio addLogReporteMinisterio(DataRow item)
        {
            LogReporteMinisterio logReporteMinisterio = new LogReporteMinisterio();
            logReporteMinisterio.LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
            logReporteMinisterio.LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
            logReporteMinisterio.LRMI_TRANSACCION_NB = int.Parse(item["LRMI_TRANSACCION_NB"].ToString());
            logReporteMinisterio.LRMI_LLAVE_V2 = item["LRMI_LLAVE_V2"].ToString();
            logReporteMinisterio.LRMI_FECREGISTRO_DT = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
            logReporteMinisterio.LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
            try
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = double.Parse(item["LRMI_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = 0;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = item["LRMI_CAMPO2_V2"].ToString();
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = string.Empty;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.UtcNow;
            }


            return logReporteMinisterio;
        }
        private DataTable getTransacciones()
        {
            DataTable dtTx = new DataTable();
            dtTx.Columns.Add("Id", typeof(int));
            dtTx.Columns.Add("Tx", typeof(string));
            dtTx.Rows.Add(3, "Ordenes Cargue");
            dtTx.Rows.Add(4, "Manifiesto");
            dtTx.Rows.Add(5, "Cumplir Orden");
            dtTx.Rows.Add(6, "Cumplir Manifiesto");
            dtTx.Rows.Add(9, "Anular Orden");
            dtTx.Rows.Add(10, "Propietarios Nit");
            dtTx.Rows.Add(11, "Propietarios Cedula");
            dtTx.Rows.Add(12, "Conductores");
            dtTx.Rows.Add(13, "Clientes Nit");
            dtTx.Rows.Add(14, "Clientes Cedula");
            dtTx.Rows.Add(15, "Vehiculos");
            dtTx.Rows.Add(16, "Trailers");
            dtTx.Rows.Add(32, "Anular Manifiestos");
            return dtTx;
        }

        private void cbxTransacciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IdTX = int.Parse(cbxTransacciones.SelectedValue.ToString());
                //txbLlave.Text = string.Empty;
                LLogReporteMinisterio.Clear();                
            }
            catch (Exception ex)
            {

                IdTX = 16;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            LLogReporteMinisterio.Add(getLogReporteMinisterio());
            txbXmlRecibido.Text = string.Empty;
            txbXmlEnvio.Text = string.Empty;
            //LLogReporteMinisterio.Add(getLogReporteMinisterio());
            switch (IdTX)
            {
                case 10:
                    {
                        List<LogReporteMinisterio> propietarioNit = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 10);
                        foreach (var item in propietarioNit)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 11:
                    {
                        List<LogReporteMinisterio> propietarioCedula = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 11);
                        foreach (var item in propietarioCedula)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 12:
                    {
                        List<LogReporteMinisterio> conductores = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 12);
                        foreach (var item in conductores)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 15:
                    {
                        List<LogReporteMinisterio> vehiculos = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 15);
                        foreach (var item in vehiculos)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 16:
                    {
                        List<LogReporteMinisterio> trailers = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 16);
                        foreach (var item in trailers)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 13:
                    {
                        List<LogReporteMinisterio> clientesNit = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 13);
                        foreach (var item in clientesNit)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 14:
                    {
                        List<LogReporteMinisterio> clientesCedula = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 14);
                        foreach (var item in clientesCedula)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 3:
                    {
                        List<LogReporteMinisterio> ordenCargue = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 3);
                        foreach (var item in ordenCargue)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 4:
                    {
                        List<LogReporteMinisterio> planilla = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 4);
                        foreach (var item in planilla)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 5:
                    {
                        List<LogReporteMinisterio> cumplidoRemesa = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 5);
                        foreach (var item in cumplidoRemesa)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 6:
                    {
                        List<LogReporteMinisterio> cumplirManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 6);
                        foreach (var item in cumplirManifiesto)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 9:
                    {
                        List<LogReporteMinisterio> anularOrden = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 9);
                        foreach (var item in anularOrden)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                case 32:
                    {
                        List<LogReporteMinisterio> anularManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 32);
                        foreach (var item in anularManifiesto)
                        {
                            procesarRegistro(item);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void procesarRegistro(LogReporteMinisterio p)
        {
            _logReporteMinisterio = p;
            DataTable dt_datos = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_LLAVE" };
            _vParametros = new object[1] { p.LRMI_LLAVE_V2 };
            Factory data = new Factory(Usuario, Password, Ambiente);
            string funcion = string.Empty;
            switch (p.LRMI_TRANSACCION_NB)
            {
                case 3:
                    {
                        funcion = "PK_MINISTERIO_XML_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 4:
                    {
                        funcion = "PK_MINISTERIO_XML_MANIFIESTO_CARGA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 5:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIDO_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 6:
                    {
                        funcion = "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 9:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_REMESA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 10:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 11:
                    {
                        funcion = "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 12:
                    {
                        funcion = "PK_MINISTERIO_XML_CONDUCTORES";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 13:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_NIT";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 14:
                    {
                        funcion = "PK_MINISTERIO_XML_CLIENTES_CEDULA";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 15:
                    {
                        funcion = "PK_MINISTERIO_XML_VEHICULOS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 16:
                    {
                        funcion = "PK_MINISTERIO_XML_TRAILERS";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                case 32:
                    {
                        funcion = "PK_MINISTERIO_XML_ANULAR_MANIFIESTO";
                        dt_datos = data.getTable(funcion, _nParametros, _vParametros);
                        if (dt_datos.Rows.Count > 0)
                        {
                            foreach (DataRow drw in dt_datos.Rows)
                            {
                                procesarFuncion(funcion, drw, p);
                            }
                        }
                        else
                        {
                            procesarSelectSinValores(funcion, p);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void procesarFuncion(string funcion, DataRow drw, LogReporteMinisterio p)
        {
            string rutaArchivo = p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + p.LRMI_OFICINA_NB + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            switch (funcion)
            {
                case "PK_MINISTERIO_XML_REMESA"://3
                    {
                        try
                        {
                            xml_envio = gxml.procesar_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA"://4
                    {
                        try
                        {
                            xml_envio = gxml.procesar_manifiesto_carga(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA"://5
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplido_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO"://6
                    {
                        try
                        {
                            xml_envio = gxml.procesar_cumplir_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT"://10
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA"://11
                    {
                        try
                        {
                            xml_envio = gxml.procesar_propietarios_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES"://12
                    {
                        try
                        {
                            xml_envio = gxml.procesar_conductores(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT"://13
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA"://14
                    {
                        try
                        {
                            xml_envio = gxml.procesar_clientes_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS"://16
                    {
                        try
                        {
                            xml_envio = gxml.procesar_vehiculos(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS"://17
                    {
                        try
                        {
                            xml_envio = gxml.procesar_trailers(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_REMESA"://9
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO"://32
                    {
                        try
                        {
                            xml_envio = gxml.procesar_anular_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                        }
                        catch (Exception ex)
                        {
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                default:
                    break;
            }
            txbXmlEnvio.Text = xml_envio;
        }
        private void procesarSelectSinValores(string funcion, LogReporteMinisterio p)
        {
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            xml_envio = gxml.SelectSinValores(funcion, p);
            txbXmlEnvio.Text = xml_envio;
            xml_recibido = gxml.ReturnSinValores(funcion, -3, "R", p);
        }
        private void procesarEnvioMinisterio(string v, string xml_envio, string xml_recibido, LogReporteMinisterio p)
        {
            string ruta = @"c:\transer\ws\web_ministerio\" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";
            bool continuar = false;
            GenerarXml gxml = new GenerarXml();
            //string LRMI_ESTADO = string.Empty;
            double DELM_IDMINISTERIO = -1234567890;
            #region Definicion de carga del documento XmlDocument xmlReturn

            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
                continuar = true;
            }
            catch (XmlException ex)
            {
                try
                {
                    xml_recibido = gxml.maquetarXMLError(xml_recibido, -2, "P", p);
                    xmlReturn.LoadXml(xml_recibido);
                    continuar = true;
                }
                catch (Exception exx)
                {

                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                continuar = false;
            }
            #endregion fin de la Definicion de carga del documento XmlDocument xmlReturn
            #region Definicion del bloque procesar respuesta
            while (continuar)
            {
                XmlElement root = xmlReturn.DocumentElement;
                try
                {
                    xmlReturn.Save(ruta);
                }
                catch (Exception ex)
                {

                }
                if (continuar)
                {
                    XmlNodeList elemListErrorTYS = root.GetElementsByTagName("ErrorTYS");
                    if (elemListErrorTYS.Count > 0)
                    {
                        XmlNodeList elemListEstadoRegistro = root.GetElementsByTagName("EstadoRegistro");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListEstadoRegistro.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            MessageBox.Show(xml_recibido,"Registro Sin valores",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //httpwebrequestFunction._status = elemListErrorTYS[i].InnerXml;
                            p.LRMI_ESTADO_V2 = elemListEstadoRegistro[i].InnerXml;
                            continuar = false;
                            break;
                        }
                        XmlNodeList elemListCodigoError = root.GetElementsByTagName("CodigoError");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListCodigoError.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListCodigoError[i].InnerXml.ToString());
                            continuar = false;
                            break;
                        }
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        if (elemListErrorMSG[i].InnerXml.ToString().Contains("DUPLICADO"))
                        {
                            MessageBox.Show(xml_recibido,"Registro DUPLICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            p.LRMI_ESTADO_V2 = "E";
                            DELM_IDMINISTERIO = getId(elemListErrorMSG[i].InnerXml.ToString());
                        }
                        else
                        {
                            MessageBox.Show(xml_recibido,"Registro Rechazado por el ministerio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            p.LRMI_ESTADO_V2 = "R";
                            DELM_IDMINISTERIO = -1;
                        }
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListingresoid = root.GetElementsByTagName("ingresoid");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListingresoid.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        MessageBox.Show(xml_recibido,"Registro Enviado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        p.LRMI_ESTADO_V2 = "E";
                        try
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListingresoid[i].InnerXml);
                        }
                        catch (Exception ex)
                        {
                            DELM_IDMINISTERIO = -123456;
                        }
                        continuar = false;
                        break;
                    }
                }
            }

            if (DELM_IDMINISTERIO == -1234567890)
            {
                continuar = false;
            }
            else
            {
                continuar = true;
            }

            #endregion fin de la Definicion del bloque procesar respuesta

            if (continuar && p.LRMI_ESTADO_V2 != "P")
            {
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    if (p.LRMI_CAMPO1_NB == 1)
                    {
                        p.LRMI_CAMPO1_NB = 2;
                    }
                    else
                    {
                        p.LRMI_CAMPO1_NB = 0;
                    }
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_CAMPO1", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                    _vParametros = new object[4] { p.LRMI_ESTADO_V2, p.LRMI_CAMPO1_NB, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                    try
                    {
                        data.executeCommand("UpdateLogReporteMinisterio", _nParametros, _vParametros);
                    }
                    catch (Exception ex)
                    {
                        continuar = false;
                    }
                }
            }
            if (continuar)
            {
                using (Factory data = new Factory(Usuario, Password, Ambiente))
                {
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[9] { ":secuencia", ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB", ":LRMI_TRANSACCION_NB", ":LRMI_LLAVE_V2", ":LRMI_ESTADO_V2", ":DELM_IDMINISTERIO_NB", ":DELM_XMLENVIADO_XML", ":DELM_XMLRECIBIDO_XML" };
                    _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, xml_envio, xml_recibido };
                    try
                    {
                        data.executeCommand("InsertDetLogMinisterio", _nParametros, _vParametros);
                    }
                    catch (Exception)
                    {
                        continuar = false;
                    }
                }
            }
        }

        private double getId(string xmlElement)
        {
            //DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
            double DELM_IDMINISTERIO_NB = -1;
            bool bid = false;
            string tid = string.Empty;
            for (int i = 9; i < xmlElement.Length; i++)
            {
                if (xmlElement.Substring(i, 1) == " ")
                {
                    DELM_IDMINISTERIO_NB = int.Parse(tid);
                    break;
                }
                if (bid)
                {
                    tid += xmlElement.Substring(i, 1);
                }
                if (xmlElement.Substring(i, 1) == ":")
                {
                    bid = true;
                }
            }
            return DELM_IDMINISTERIO_NB;
        }

        private double getSecuenciaDetLogMinisterio(LogReporteMinisterio p)
        {
            double delm_secuencia = 0;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB" };
            _vParametros = new object[2] { p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
            Factory data = new Factory(Usuario, Password, Ambiente);
            var dtDetLogMinisterio = data.getTable("getDetLogMinisterio", _nParametros, _vParametros);
            if (dtDetLogMinisterio.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetLogMinisterio.Rows)
                {
                    try
                    {
                        delm_secuencia = double.Parse(dr["DELM_SECUENCIA_NB"].ToString());
                    }
                    catch (Exception ex)
                    {
                        delm_secuencia = 0;
                    }
                }
                delm_secuencia++;
            }
            else
            {
                delm_secuencia = 1;
            }

            return delm_secuencia;
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("logLogicaNegocio.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string xml_recibido = string.Empty;
            xml_recibido = enviar(txbXmlEnvio.Text);
            txbXmlRecibido.Text = xml_recibido;
            procesarEnvioMinisterio("Envio Unitario", txbXmlEnvio.Text, xml_recibido, _logReporteMinisterio);

        }
        public string enviar(string xml)
        {
            string xml_respuesta = string.Empty;
            srRndcEnvioUnitario.BPMServicesClient envio_xml = new srRndcEnvioUnitario.BPMServicesClient();
            xml_respuesta = envio_xml.AtenderMensajeRNDC(xml);
            return xml_respuesta;
        }

        private void txbLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscar();
            }
            
        }
    }
}
