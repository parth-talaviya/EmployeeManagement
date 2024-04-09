namespace UserManagement.Application.Handlers.Role;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, RoleViewModel?>
{
    private readonly IRoleService _roleService;

    public DeleteRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public Task<RoleViewModel?> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        return _roleService.DeleteRoleAsync(request.Id, cancellationToken);
    }
}