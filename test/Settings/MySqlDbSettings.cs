namespace Catalog.Settings
{
    public class MySqlDbSettings
    {
        public string Password { get; set; }
        public string Server { get; set; }
        public string UserId { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }


        public static string ConnectionString { get; } = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MySqlSettings").Get<MySqlDbSettings>().ToString();
        public override string ToString()
        {
            return $"server={Server};database={Database};user={UserId};port={Port};password={Password};";
        }
    }
}
