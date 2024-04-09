namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IUserRepository))]
public sealed class UserRepository : IUserRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UserRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.AddParameters(user);

        await connection.ExecuteAsync("CreateUser", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
        int newUserId = parameters.Get<int>("@Id");

        return newUserId;
    }

    public async Task<User?> EditUserAsync(User user, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new { user.Name, user.Id, user.ImageURL, user.Email, user.PhoneNumber, user.City });

        return await connection
            .QueryFirstOrDefaultAsync<User>("EditUser", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<User?> EditUserPasswordAsync(User user, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new { user.Id, user.Password });

        return await connection
            .QueryFirstOrDefaultAsync<User>("EditUserPassword", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<User?> DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<User>("DeleteUser", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        return await connection.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection.QueryFirstOrDefaultAsync<User>("GetUsersById", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<int?> GetUserIdAsync(string userName, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Name", userName);

        return await connection.QueryFirstOrDefaultAsync<int?>(
            "SELECT Id FROM [User] WHERE Name = @Name", parameters).ConfigureAwait(false);
    }
}