namespace UserManagement.Application.Handlers.User;

public sealed class EditUserHandler : IRequestHandler<EditUserCommand, UserUpdateProfileViewModel?>
{
    private readonly IUserService _userRegisterService;

    public EditUserHandler(IUserService userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }

    public Task<UserUpdateProfileViewModel?> Handle(EditUserCommand editUserCommand,
        CancellationToken cancellationToken)
    {
        return _userRegisterService.EditUserAsync(editUserCommand.UserUpdateProfileViewModel, cancellationToken);
    }
}