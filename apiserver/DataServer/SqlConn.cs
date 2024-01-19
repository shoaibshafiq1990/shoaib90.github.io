namespace apiserver.DataServer
{
    public class SqlConn
    {
        public static string GetConnectionString()
        {
            return @"Data Source=tcp:10.10.204.171,1433;Initial Catalog=servicedesk;User ID=sa;Password=Giga$Byte;";
        }
    }
}
