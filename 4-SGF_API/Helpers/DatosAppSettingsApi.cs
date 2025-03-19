namespace _4_SGF_API.Helpers
{
    public static class DatosAppSettingsApi
    {
        public static string GetData(string cadena)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = builder.Build();
            return config.GetSection(cadena).Value;
        }
    }
}