using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;

namespace Transer.Tecnologia.Automatizacion.Infrastructure
{
    public partial class Factory:IDisposable
    {
        private bool disposed = false;
        private Security _Security;
        private BuildSelect SelectCommand;
        public Factory(string user, string password, string ambiente)
        {
            _Security = new Security(user, password, ambiente);
            SelectCommand = new BuildSelect();
        }

        public DataTable getTable(string select, string[] _nParametros, object[] _vParametros)
        {
            return GetTable(select,_nParametros,_vParametros);
        }
        public DataTable getTable(string select)
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] {  };
            _vParametros = new object[0] {  };
            return GetTable(select, _nParametros, _vParametros);
        }
        public int executeCommand(string select, string[] _nParametros, object[] _vParametros)
        {
            return ExecuteCommand(select, _nParametros, _vParametros);
        }

        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
