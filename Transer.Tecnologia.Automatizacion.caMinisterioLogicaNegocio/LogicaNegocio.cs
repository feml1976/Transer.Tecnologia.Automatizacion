using System;
using System.Collections.Generic;
using Transer.Tecnologia.Automatizacion.EntityMinisterio;
using Transer.Tecnologia.Automatizacion.Infrastructure;
using System.Linq;
namespace Transer.Tecnologia.Automatizacion.caMinisterioLogicaNegocio
{
    public partial class LogicaNegocio : ILogicaNegocio
    {
        /*VERSION PRODUCCION*/

        private string Usuario;
        private string Password;
        private string UsuEmail;
        private string PassEmail;
        private string Ambiente;
        public string Log { get; set; }
        public ICollection<LogReporteMinisterio> ICLogReporteMinisterio { get; set; }
        public List<LogReporteMinisterio> LLogReporteMinisterio { get; set; }
        public Consola console;
        public string ExcepcionEjecucion { get; set; }
        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            //SendEmail("Pruebas", "Mensaje de prueba", "fmontoya@transer.com.co", "soporte@transer.com.co", "francisco.montoya.l@gmail.com");
            Log = string.Empty;
            Usuario = usuario;
            Password = password;
            UsuEmail = usuEmail;
            PassEmail = passEmail;
            Ambiente = ambiente;
            //console.Clear();
            //console.CBlack();
            string titulo = "                            MINISTERIO DE TRANSPORTE\r\n"+ "                            ========== == ==========\r\n";
            console = new Consola(titulo);
            ICLogReporteMinisterio = new List<LogReporteMinisterio>();
            LoadICLogReporteMinisterio();
            //LLogReporteMinisterio = new List<LogReporteMinisterio>();
            //List<LogReporteMinisterio> entityList = new List<LogReporteMinisterio>(ICLogReporteMinisterio);//.ToList<LogReporteMinisterio>;//.CopyTo(LLogReporteMinisterio[],0);
            LLogReporteMinisterio = new List<LogReporteMinisterio>(ICLogReporteMinisterio);
        }

        public void Inicio(DateTime fecini)
        {
            int Total = ICLogReporteMinisterio.Count;
            string avances = string.Empty;
            int procesado = 0;
            int txpro = 0;
            for (int i = 1; i < 32; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            List<LogReporteMinisterio> propietarioNit = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 10);
                            txpro = 0;
                            foreach (var item in propietarioNit)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Propietario con Nit" + "  Registros : " + propietarioNit.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 2:
                        {
                            List<LogReporteMinisterio> propietarioCedula = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 11);
                            txpro = 0;
                            foreach (var item in propietarioCedula)
                            {
                                //pp("Procesando => Propietario con Cedula");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Propietario con Cedula" + "  Registros : " + propietarioCedula.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            List<LogReporteMinisterio> conductores = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 12);
                            txpro = 0;
                            foreach (var item in conductores)
                            {
                                //pp("Procesando => Conductores");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Conductores" + "  Registros : " + conductores.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            List<LogReporteMinisterio> vehiculos = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 15);
                            txpro = 0;
                            foreach (var item in vehiculos)
                            {
                                //pp("Procesando => Vehiculos");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Vehiculos" + "  Registros : " + vehiculos.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            List<LogReporteMinisterio> trailers = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 16);
                            txpro = 0;
                            foreach (var item in trailers)
                            {
                                //pp("Procesando => Trailers");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Trailers" + "  Registros : " + trailers.Count + " Procesados : " + txpro;
                                pp(avances);

                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 6:
                        {
                            List<LogReporteMinisterio> clientesNit = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 13);
                            txpro = 0;
                            foreach (var item in clientesNit)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Clientes Nit" + "  Registros : " + clientesNit.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 7:
                        {
                            List<LogReporteMinisterio> clientesCedula = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 14);
                            txpro = 0;
                            foreach (var item in clientesCedula)
                            {
                                //pp("Procesando => Clientes con Cedula");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Clientes Cedula" + "  Registros : " + clientesCedula.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 8:
                        {
                            List<LogReporteMinisterio> ordenCargue = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 3);
                            txpro = 0;
                            foreach (var item in ordenCargue)
                            {
                                //pp("Procesando => Orden de Cargue");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Orden de Cargue" + "  Registros : " + ordenCargue.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 9:
                        {
                            List<LogReporteMinisterio> planilla = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 4);
                            txpro = 0;
                            foreach (var item in planilla)
                            {
                                //pp("Procesando => Planilla");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Planilla" + "  Registros : " + planilla.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 10:
                        {
                            List<LogReporteMinisterio> cumplidoRemesa = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 5);
                            txpro = 0;
                            foreach (var item in cumplidoRemesa)
                            {
                                //pp("Procesando => Cumplido Orden de Cargue");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Cumplido Remesa" + "  Registros : " + cumplidoRemesa.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 11:
                        {
                            List<LogReporteMinisterio> cumplirManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 6);
                            txpro = 0;
                            foreach (var item in cumplirManifiesto)
                            {
                                //pp("Procesando => Cumplido Planilla");
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Cumplido Planilla" + "  Registros : " + cumplirManifiesto.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 12:
                        {
                            List<LogReporteMinisterio> anularManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 29);
                            txpro = 0;
                            foreach (var item in anularManifiesto)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Anular Planilla" + "  Registros : " + anularManifiesto.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 13:
                        {
                            List<LogReporteMinisterio> anularManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 28);
                            txpro = 0;
                            foreach (var item in anularManifiesto)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Anular Planilla" + "  Registros : " + anularManifiesto.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 14:
                        {
                            List<LogReporteMinisterio> anularManifiesto = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 32);
                            txpro = 0;
                            foreach (var item in anularManifiesto)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Anular Planilla" + "  Registros : " + anularManifiesto.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 15:
                        {
                            List<LogReporteMinisterio> anularOrden = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 9);
                            txpro = 0;
                            foreach (var item in anularOrden)
                            {
                                procesado++;
                                txpro++;
                                avances = string.Empty;
                                avances += fecini.ToLongDateString() + " " + fecini.ToLongTimeString() + "\r\n";
                                avances += "Registros : " + LLogReporteMinisterio.Count + " Procesados : " + procesado + " Pendientes : " + (LLogReporteMinisterio.Count - procesado) + "\r\n";
                                avances += "Procesando => Anular Orden de Cargue" + "  Registros : " + anularOrden.Count + " Procesados : " + txpro;
                                pp(avances);
                                procesarRegistro(item);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            //List<LogReporteMinisterio> perro = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 6); //LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB = 6);
            /*if (ICLogReporteMinisterio.Count > 0)
            {
                foreach (var p in ICLogReporteMinisterio)
                {
                    console.CBlack();
                    console.Clear();
                    console.Ih("      ", false);
                    console.Ih("      APLICATIVO MINISTERIO DE TRANSPORTE RNDC ver 1.0.0", false);
                    console.Ih("      ========== ========== == ========== ==== *** * * *", false);
                    console.Ih("     Registros a procesar : " + Total + ". Procesadas : " + Procesadas + ". Pendientes : " + (Total - Procesadas).ToString() + "\r\n", false);
                    procesarRegistro(p);
                }
            }
            jugar();*/
        }

        private void ProcesarTx(int transaccion)
        {            
            List<LogReporteMinisterio> perro = LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 6); //LLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB = 6);
            foreach (var item in perro)
            {
                console.Ih(item.LRMI_LLAVE_V2 + " " + item.LRMI_SECUENCIA_NB + " " + item.LRMI_OFICINA_NB + " " + item.LRMI_TRANSACCION_NB);
            }
        }
    }
}
