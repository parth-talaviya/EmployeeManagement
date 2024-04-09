namespace UserManagement.Application.Handlers.User;

public sealed class EditUserPassowrdHandler : IRequestHandler<EditUserPasswordCommand, UserPasswordUpdateViewModel?>
{
    private readonly IUserService _userRegisterService;

    public EditUserPassowrdHandler(IUserService userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }

    public Task<UserPasswordUpdateViewModel?> Handle(EditUserPasswordCommand editUserPasswordCommand, CancellationToken cancellationToken)
    {
        return _userRegisterService.EditUserPasswordAsync(editUserPasswordCommand.UserPasswordUpdateViewModel, cancellationToken);
    }
}