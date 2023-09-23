namespace EXDIBO.Data
{
    public class DBContext
    {
        private string _ConnectionString = string.Empty;
        public DBContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _ConnectionString = builder.GetSection("ConnectionStrings:ConecctionSQL").Value;
        }

        public string GetConnectionString()
        {
            return _ConnectionString;
        }
    }
}
