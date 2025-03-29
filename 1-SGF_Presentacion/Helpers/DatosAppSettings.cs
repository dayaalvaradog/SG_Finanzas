namespace _1_SGF_Presentacion.Helpers
{
    public static class DatosAppSettings
    {
        public static string GetUrlAPI()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = builder.Build();
            string value = config.GetSection("Url:API").Value;
            return value;
        }

        public static string GetData(string cadena)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = builder.Build();
            string value = config.GetSection(cadena).Value;
            return value;
        }
    }
}


