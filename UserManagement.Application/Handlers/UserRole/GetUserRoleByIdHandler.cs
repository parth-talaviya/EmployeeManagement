namespace UserManagement.Application.Handlers.UserRole;

public sealed class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, IEnumerable<UserRoleViewModel?>>
{
    private readonly IUserRoleService _userRoleService;

    public GetUserRoleByIdHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public Task<IEnumerable<UserRoleViewModel?>> Handle(GetUserRoleByIdQuery request,
        CancellationToken cancellationToken)
    {
        return _userRoleService.GetUserRoleAsync(request.UserId, cancellationToken);
    }
}