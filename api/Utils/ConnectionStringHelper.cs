

namespace api.Utils;
using Npgsql;

public class ConnectionStringHelper
{
  public static string GetConnectionString(WebApplicationBuilder builder) =>
    GetConnectionStringFromEnv() ?? builder.Configuration.GetConnectionString("ItemContext");

  private static string? GetConnectionStringFromEnv()
  {
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    if (databaseUrl is null)
    {
      return null;
    }

    var databaseUri = new Uri(databaseUrl);
    var userInfo = databaseUri.UserInfo.Split(':');

    var builder = new NpgsqlConnectionStringBuilder
    {
      Host = databaseUri.Host,
      Port = databaseUri.Port,
      Username = userInfo[0],
      Password = userInfo[1],
      Database = databaseUri.LocalPath.TrimStart('/')
    };

    return builder.ToString();
  }

}
