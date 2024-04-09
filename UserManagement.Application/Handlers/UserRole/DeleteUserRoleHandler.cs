namespace UserManagement.Application.Handlers.UserRole;

public sealed class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, UserRoleViewModel?>
{
    private readonly IUserRoleService _userRoleService;

    public DeleteUserRoleHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public Task<UserRoleViewModel?> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        return _userRoleService.DeleteUserRoleAsync(request.Id, cancellationToken);
    }
}