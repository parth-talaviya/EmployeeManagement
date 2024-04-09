namespace UserManagement.Application.Handlers.User;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserViewModel>>
{
    private readonly IUserService _userService;

    public GetAllUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IEnumerable<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetAllUserAsync(cancellationToken).ConfigureAwait(false);
    }
}