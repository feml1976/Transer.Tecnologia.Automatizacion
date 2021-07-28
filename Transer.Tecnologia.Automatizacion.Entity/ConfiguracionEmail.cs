namespace Transer.Tecnologia.Automatizacion.Entity
{
    public class ConfiguracionEmail
    {
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string Para { get; set; }
        public string Copia { get; set; }
        public string CopiaOculta { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public bool enableSsl { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string cuentaCorreo { get; set; }
        public string Titulo { get; set; }
    }
}
