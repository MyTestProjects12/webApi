namespace Catalog.Settings
{
    public class SqlDbSettings
    {
        public string Password { get; set; }
        public string Server { get; set; }
        public string UserId { get; set; }
        public string Database { get; set; }


        public static string ConnectionString { get; } = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SqlDbSettings").Get<SqlDbSettings>().ToString();
        public override string ToString()
        {
            return $"Server={Server};Database={Database};User Id={UserId};Password={Password};";
        }
    }
}
