namespace UserManagement.Application.Handlers.User;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserViewModel?>
{
    private readonly IUserService _userService;

    public GetUserByIdHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<UserViewModel?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return _userService.GetUserAsync(request.Id, cancellationToken);
    }
}