using System;
using System.Diagnostics;

namespace Transer.Tecnologia.Automatizacion.CallExecute
{
    public class CallExecutes
    {
        public string generarZIP(string ex1, string ex2)
        {
            string ejecucion = "O.K";
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"c:\WinZip\WINZIP32.EXE ";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-min -a " + ex1 + " " + ex2;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
                ejecucion = ex.Message;
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
                ejecucion = ex.Message;
            }
            return ejecucion;
        }
    }
}
