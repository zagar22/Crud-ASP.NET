using System.Data.SqlClient;

namespace TpCrudAsp.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string GetCadenaSql()
        {
            return cadenaSql;
        }
    }
}
