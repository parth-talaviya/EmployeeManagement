namespace UserManagement.Application.Handlers.Role;

public sealed class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, IEnumerable<RoleViewModel>>
{
    private readonly IRoleService _roleService;

    public GetAllRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public Task<IEnumerable<RoleViewModel>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
    {
        return _roleService.GetAllRoleAsync(cancellationToken);
    }
}