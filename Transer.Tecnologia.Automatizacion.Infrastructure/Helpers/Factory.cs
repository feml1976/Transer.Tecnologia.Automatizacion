using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transer.Tecnologia.Automatizacion.Infrastructure
{
    public partial class Factory
    {
        public Consola console;
        public Factory()
        {
            console = new Consola("        Factory");
        }
        public Factory(string Nombreprograma)
        {
            console = new Consola("        " + Nombreprograma);
        }
        private DataTable GetTable(string select, string[] _nParametros, object[] _vParametros)
        {
            DataTable dtTmp = new DataTable();
            using (OracleConnection conn = new OracleConnection(_Security.cadena))
            {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                OracleCommand cmd = new OracleCommand(SelectCommand.GetCommand(select), conn);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                switch (select)
                {
                    case "FDB_LEER_ANEXOS_DIAN":
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            break;
                        }
                    default:
                        {
                            cmd.CommandType = CommandType.Text;
                            break;
                        }
                }
                OracleParameter p_refcursor = new OracleParameter();
                p_refcursor.OracleDbType = OracleDbType.RefCursor;
                p_refcursor.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p_refcursor);


                for (int i = 0; i < _nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                try
                {
                    adapter.Fill(dtTmp);
                }
                catch (OracleException ex)
                {
                     if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(SelectCommand.GetCommand(select), ex);
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(SelectCommand.GetCommand(select), ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dtTmp;
        }
        private int ExecuteCommand(string select, string[] _nParametros, object[] _vParametros)
        {
            int recordProcessed = int.MinValue;
            using (OracleConnection conn = new OracleConnection(_Security.cadena))
            {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                OracleCommand cmd = new OracleCommand(SelectCommand.GetCommand(select), conn)
                {
                    CommandType = CommandType.Text
                };
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                for (int i = 0; i < _nParametros.Length; i++)
                {
                    cmd.Parameters.Add(parametroInt(_nParametros[i], _vParametros[i]));
                }
                try
                {
                    conn.Open();
                    recordProcessed = (int)cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsOracleException(SelectCommand.GetCommand(select), ex);
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    PrcsException(SelectCommand.GetCommand(select), ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return recordProcessed;
        }

        private OracleParameter parametroInt(string pnombre, object valor)
        {

            bool continua = true;
            OracleParameter op = new OracleParameter();
            op.ParameterName = pnombre;
            op.Direction = ParameterDirection.Input;
            while (continua)
            {
                if (valor.GetType() == Type.GetType("System.String"))
                {
                    switch (pnombre)
                    {
                        case ":soaprespuesta":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":xmlfactura":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":filedata":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapenviado":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapEnviado":
                            {

                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":soapRecibido":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    writer.Write(valor);
                                    writer.Flush();
                                    stream.Position = 0;
                                    byte[] bfiledata = new byte[stream.Length];
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":indi_xmllegal":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                string perro = (string)valor;
                                op.OracleDbType = OracleDbType.Clob;
                                op.Direction = ParameterDirection.Input;
                                op.Value = perro;
                                continua = false;
                                break;
                            }
                        case ":indi_xmlrec":
                            {
                                //OracleParameter psoapEnviado = new OracleParameter(":soapEnviado", OracleDbType.Blob);
                                string svalor = (string)valor;
                                byte[] bfiledata = Encoding.ASCII.GetBytes(svalor);
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        default:
                            {
                                op.Value = (string)valor;
                                op.OracleDbType = OracleDbType.Varchar2;
                                continua = false;
                                break;
                            }
                    }
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Int32"))
                {
                    op.Value = (int)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Double"))
                {
                    op.Value = (Double)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Int64"))
                {
                    op.Value = (long)valor;
                    op.OracleDbType = OracleDbType.Int32;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.DateTime"))
                {
                    DateTime fecha = (DateTime)valor;
                    op.Value = fecha;
                    op.OracleDbType = OracleDbType.Date;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Byte[]"))
                {
                    switch (pnombre)
                    {
                        case ":indi_repgrafica":
                            {
                                byte[] bfiledata = (byte[])valor;
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        case ":indi_xmlrec":
                            {
                                byte[] bfiledata = (byte[])valor;
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    StreamWriter writer = new StreamWriter(stream);
                                    stream.Read(bfiledata, 0, System.Convert.ToInt32(stream.Length));
                                    stream.Close();
                                    op.Value = bfiledata;
                                    op.OracleDbType = OracleDbType.Blob;
                                    stream.Flush();
                                }
                                continua = false;
                                break;
                            }
                        default:
                            {
                                byte[] myBytes = (byte[])valor;
                                op.Value = myBytes;
                                op.OracleDbType = OracleDbType.Clob;
                                continua = false;
                                break;
                            }
                    }
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Byte"))
                {
                    byte[] myBytes = (byte[])valor;
                    op.Value = myBytes;
                    op.OracleDbType = OracleDbType.Clob;
                    continua = false;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Sbyte"))
                {
                    byte[] myBytes = (byte[])valor;
                    op.Value = myBytes;
                    op.OracleDbType = OracleDbType.Clob;
                    continua = false;
                    break;
                }
                if (continua)
                {
                    continua = false;
                    break;
                }
            }
            return op;
        }
        private void log(string texto)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(texto);
            }
        }

        private void PrcsException(string select, Exception ex)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("Error", typeof(string));
            dtTmp.Rows.Add(ex.Message);
            logException(SelectCommand.GetCommand(select), dtTmp);
        }
        private void PrcsOracleException(string select, OracleException ex)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("Number", typeof(int));
            dtTmp.Columns.Add("Procedure", typeof(string));
            dtTmp.Columns.Add("DataSource", typeof(string));
            dtTmp.Columns.Add("Source", typeof(string));
            dtTmp.Columns.Add("ErrorCode", typeof(int));
            dtTmp.Columns.Add("Mensaje", typeof(string));
            dtTmp.Rows.Add(ex.Number, ex.Procedure, ex.DataSource, ex.Source, ex.ErrorCode, ex.Message.ToString());
            /*dtTmp.Rows.Add(ex.Procedure);
            dtTmp.Rows.Add(ex.DataSource);
            dtTmp.Rows.Add(ex.Source);
            dtTmp.Rows.Add(ex.ErrorCode);
            dtTmp.Rows.Add(ex.Message);*/
            logOracleException(select, dtTmp);
            console.ReadKey("Se Presento un error...!!!!\r\n\r\n" + select + "\r\n\r\n" + ex.Message, true);
        }
        private void logException(string texto, DataTable dtMensaje)
        {
            if (dtMensaje.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMensaje.Rows)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                        writer.WriteLine("Se Produjo un error al ejecutar el comando de tipo Exception:");
                        writer.WriteLine(texto);
                        writer.WriteLine(" ");
                        writer.WriteLine("Informacion Asociada al Error... ");
                        writer.WriteLine("Error : " + dr["Error"].ToString());
                        writer.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        writer.WriteLine(" ");
                    }
                }
            }
        }
        private void logOracleException(string texto, DataTable dtMensaje)
        {
            if (dtMensaje.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMensaje.Rows)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                        writer.WriteLine("Se Produjo un error al ejecutar el comando de tipo OracleException:");
                        writer.WriteLine(texto);
                        writer.WriteLine(" ");
                        writer.WriteLine("Informacion Asociada al Error... ");
                        writer.WriteLine("Number : " + dr["Number"].ToString());
                        writer.WriteLine("Procedure : " + dr["Procedure"].ToString());
                        writer.WriteLine("DataSource : " + dr["DataSource"].ToString());
                        writer.WriteLine("Source : " + dr["Source"].ToString());
                        writer.WriteLine("ErrorCode : " + dr["ErrorCode"].ToString());
                        writer.WriteLine("Mensaje : " + dr["Mensaje"].ToString());
                        writer.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                        writer.WriteLine(" ");
                    }
                }
            }
        }
    }

    internal class Security
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string cadena { get; set; }
        public string ip { get; set; }
        public string sid { get; set; }
        public string ambiente { get; set; }
        public Security(string usuario, string password, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.ambiente = ambiente;
            //this.usuario = Base64Decode(usuario);
            //this.password = Base64Decode(password);
            inicialization();
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string texto = System.Convert.ToBase64String(plainTextBytes);
            return texto;
        }


        private void inicialization()
        {
            switch (Base64Decode(ambiente))
            {
                case "desarrollo":
                    {
                        ip = "192.168.30.148";
                        sid = "PERSONAL.transer.local";
                        break;
                    }
                case "produccion":
                    {
                        ip = "192.168.30.119";
                        sid = "DBMILE";
                        break;
                    }
                case "operativo":
                    {
                        ip = "192.168.30.122";
                        sid = "dbclon.transer.local";
                        //sid = "dbclon";
                        break;
                    }
                default:
                    {
                        ip = "192.168.30.148";
                        sid = "PERSONAL.transer.local";
                        break;
                    }
            }
            cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ip + ")(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=" + sid + ")(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            cadena += "Min Pool Size=2;" +//Tamaño de grupo mínimo del pool, definimos el número mínimo de conexiones que deben mantenerse en el grupo. 
                 "Max Pool Size=8;" +//Tamaño máximo del pool, define la cantidad máxima de conexiones que pueden mantenerse en el grupo.
                 "Connection Lifetime=60;" +//Duración de la conexión, define la duración máxima (en segundos) que una conexión puede permanecer en caché en el grupo.
                 "Connection Timeout=60;" +//Tiempo de espera de conexión Esta es la cantidad de tiempo (en segundos) que cada solicitud de conexión se da para conectarse a la base de datos. antes de que se levante una excepción de tiempo de espera
                 "Incr Pool Size=1;" +//Tamaño del pool de Incr, define el número de conexiones nuevas para crear cada vez que se necesitan más conexiones en el grupo de conexiones.
                 "Decr Pool Size=1;" +//Tamaño del grupo de escritorios El servicio de agrupación de conexiones intentará cerrar conexiones en caché que no están en uso por más de 3 minutos. Este atributo define el número máximo de conexiones que se pueden cerrar de una vez.
                 "User ID=" + Base64Decode(usuario) + ";" +
                 "Password=" + Base64Decode(password) + ";";
            /*"User ID=" + usuario + ";" +
                 "Password=" + password + ";";*/
        }

    }

}
