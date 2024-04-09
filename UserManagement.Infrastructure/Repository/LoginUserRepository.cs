namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(ILoginUserRepository))]
public sealed class LoginUserRepository : ILoginUserRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public LoginUserRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<LoginUser?> AuthenticateLoginUserAsync(LoginUser loginUser, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@UserName", loginUser.UserName);
        parameters.Add("@Password", loginUser.Password);

        var query = "SELECT Email, Password, Name FROM [User] WHERE Name = @UserName AND Password = @Password";

        return await connection.QueryFirstOrDefaultAsync<LoginUser>(query, parameters).ConfigureAwait(false);
    }

    public async Task SaveRefreshTokenAsync(int userId, string refreshToken, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@RefreshToken", refreshToken);
        parameters.Add("@Id", userId);

        await connection.ExecuteAsync("AddRefreshToken", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }

    public async Task<string?> GetRefreshTokenAsync(int userId, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", userId);

        return await connection
            .QueryFirstOrDefaultAsync<string>("GetRefreshToken", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
    }
}