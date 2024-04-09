namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(ISqlConnectionFactory))]
public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IOptions<SqlConnectionOptionsDto> _options;

    public SqlConnectionFactory(IOptions<SqlConnectionOptionsDto> options)
    {
        _options = options;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_options.Value.ConnectionString);
    }
}