namespace Infrastructure.Configuration;

public static class AppConfiguration
{
    public static string ConnectionString;
    static AppConfiguration()
    {
        ConnectionString = "Data Source = WIN10\\SQLEXPRESS; Initial Catalog = OnlineeShopDb; User ID = sa; Password = 246850; TrustServerCertificate = True; Encrypt = True";
    }
}
