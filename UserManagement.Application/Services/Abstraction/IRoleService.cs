namespace UserManagement.Application.Services.Abstraction;

public interface IRoleService
{
    Task<int> AddRoleAsync(AddRoleViewModel roleViewModel, CancellationToken cancellationToken);

    Task<UpdateRoleViewModel?> EditRoleAsync(UpdateRoleViewModel roleViewModel, CancellationToken cancellationToken);

    Task<RoleViewModel?> DeleteRoleAsync(int id, CancellationToken cancellationToken);

    Task<RoleViewModel?> GetRoleAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<RoleViewModel>> GetAllRoleAsync(CancellationToken cancellationToken);
}