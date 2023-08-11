using System.Data;

namespace SimpleCRUDWebAPI.Services;

public interface IDbConnectionFactory
{
    public IDbConnection CreateConnection();
}
