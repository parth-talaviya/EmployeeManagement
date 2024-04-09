namespace UserManagement.Infrastructure.Abstraction;

public interface IUserRepository
{
    Task<int> CreateUserAsync(User user, CancellationToken cancellationToken);

    Task<User?> EditUserAsync(User user, CancellationToken cancellationToken);

    Task<User?> EditUserPasswordAsync(User user, CancellationToken cancellationToken);

    Task<User?> DeleteUserAsync(int id, CancellationToken cancellationToken);

    Task<User?> GetUserAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken);

    Task<int?> GetUserIdAsync(string email, CancellationToken cancellationToken);
}