namespace UserManagement.Infrastructure.Abstraction;

public interface IRoleRepository
{
    Task<int> AddRoleAsync(Role role, CancellationToken cancellationToken);

    Task<Role?> EditRoleAsync(Role role, CancellationToken cancellationToken);

    Task<Role?> DeleteRoleAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Role>> GetAllRoleAsync(CancellationToken cancellationToken);

    Task<Role?> GetRoleAsync(int id, CancellationToken cancellationToken);
}