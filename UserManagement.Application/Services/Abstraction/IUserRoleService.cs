namespace UserManagement.Application.Services.Abstraction;

public interface IUserRoleService
{
    Task<UserRoleViewModel?> DeleteUserRoleAsync(int id, CancellationToken cancellationToken);

    Task<int> AddUserRoleAsync(AddUserRoleViewModel userRoleViewModel, CancellationToken cancellationToken);

    Task<IEnumerable<UserRoleViewModel?>> GetUserRoleAsync(int userId, CancellationToken cancellationToken);
}