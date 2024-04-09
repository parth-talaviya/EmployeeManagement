namespace UserManagement.Application.Handlers.Role;

public sealed class EditRoleHandler : IRequestHandler<EditRoleCommand, UpdateRoleViewModel?>
{
    private readonly IRoleService _roleService;

    public EditRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public Task<UpdateRoleViewModel?> Handle(EditRoleCommand command, CancellationToken cancellationToken)
    {
        return _roleService.EditRoleAsync(command.UpdateRoleViewModel, cancellationToken);
    }
}