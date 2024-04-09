namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IRoleService))]
public sealed class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<int> AddRoleAsync(AddRoleViewModel roleViewModel, CancellationToken cancellationToken)
    {
        var roles = _mapper.Map<AddRoleViewModel, Role>(roleViewModel);

        return await _roleRepository.AddRoleAsync(roles, cancellationToken).ConfigureAwait(false);
    }

    public async Task<UpdateRoleViewModel?> EditRoleAsync(UpdateRoleViewModel roleViewModel,
        CancellationToken cancellationToken)
    {
        var roles = _mapper.Map<UpdateRoleViewModel, Role>(roleViewModel);

        var updatedRole = await _roleRepository.EditRoleAsync(roles, cancellationToken).ConfigureAwait(false);

        return updatedRole != null ? _mapper.Map<Role?, UpdateRoleViewModel>(updatedRole) : null;
    }

    public async Task<IEnumerable<RoleViewModel>> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllRoleAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<List<RoleViewModel>>(roles);
    }

    public async Task<RoleViewModel?> GetRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleAsync(id, cancellationToken).ConfigureAwait(false);

        return role != null ? _mapper.Map<RoleViewModel?>(role) : null;
    }

    public async Task<RoleViewModel?> DeleteRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.DeleteRoleAsync(id, cancellationToken).ConfigureAwait(false);

        return role != null ? _mapper.Map<RoleViewModel?>(role) : null;
    }
}