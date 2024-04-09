namespace UserManagement.Application.Handlers.Role;

public sealed class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel?>
{
    private readonly IRoleService _roleService;

    public GetRoleByIdHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public Task<RoleViewModel?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return _roleService.GetRoleAsync(request.Id, cancellationToken);
    }
}