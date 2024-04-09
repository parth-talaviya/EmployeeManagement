namespace UserManagement.Infrastructure.Abstraction;

public interface IUserRoleRepository
{
    Task<int> AddUserRoleAsync(UserRole userrole, CancellationToken cancellationToken);

    Task<UserRole?> DeleteUserRoleAsync(int Id, CancellationToken cancellationToken);

    Task<IEnumerable<UserRole>> GetUserRoleAsync(int userId, CancellationToken cancellationToken);

    Task<UserRole?> AddUserRoleByIdAsync(int userId, CancellationToken cancellationToken);
}