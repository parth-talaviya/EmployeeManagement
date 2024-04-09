namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IRoleRepository))]
public sealed class RoleRepository : IRoleRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public RoleRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> AddRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var parameters = new DynamicParameters();
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.AddParameters(role);

        await connection.ExecuteAsync("AddRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
        int newContactId = parameters.Get<int>("@Id");

        return newContactId;
    }

    public async Task<Role?> EditRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var parameters = new DynamicParameters();
        parameters.AddParameters(new { role.Name, role.Id });

        return await connection
            .QueryFirstOrDefaultAsync<Role>("EditRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<Role?> DeleteRoleAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<Role>("DeleteRole", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<Role>> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        return await connection.QueryAsync<Role>("GetAllRole", commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<Role?> GetRoleAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection.QueryFirstOrDefaultAsync<Role>("GetRoleById", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}