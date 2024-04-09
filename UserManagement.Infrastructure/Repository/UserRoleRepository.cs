namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IUserRoleRepository))]
public sealed class UserRoleRepository : IUserRoleRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UserRoleRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> AddUserRoleAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(userRole);
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@UserId", userRole.UserId);
        parameters.Add("@RoleId", userRole.RoleId);

        await connection
            .ExecuteAsync("AddUserRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
        int newUserId = parameters.Get<int>("@Id");

        return newUserId;
    }

    public async Task<UserRole?> AddUserRoleByIdAsync(int userId, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@UserId", userId);
        parameters.Add("@RoleId", 2);

        return await connection
            .QueryFirstOrDefaultAsync<UserRole>("AddUserRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<UserRole?> DeleteUserRoleAsync(int userId, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);

        return await connection
            .QueryFirstOrDefaultAsync<UserRole>("DeleteUserRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<UserRole>> GetUserRoleAsync(int userId, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);

        return await connection
            .QueryAsync<UserRole>("GetUserRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }
}