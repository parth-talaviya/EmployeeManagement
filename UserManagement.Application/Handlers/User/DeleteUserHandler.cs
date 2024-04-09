namespace UserManagement.Application.Handlers.User;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserViewModel?>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserViewModel?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.DeleteUserAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}