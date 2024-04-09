namespace UserManagement.Infrastructure.Abstraction;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}