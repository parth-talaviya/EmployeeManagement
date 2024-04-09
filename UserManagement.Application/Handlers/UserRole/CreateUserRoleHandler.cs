namespace UserManagement.Application.Handlers.UserRole;

public sealed class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, AddUserRoleViewModel>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<AddUserRoleViewModel> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRoleId = await _userRoleService.AddUserRoleAsync(request.AddUserRoleViewModel, cancellationToken)
            .ConfigureAwait(false);

        var viewModel = new AddUserRoleViewModel
        {
            Id = userRoleId,
            UserId = request.AddUserRoleViewModel.UserId,
            RoleId = request.AddUserRoleViewModel.RoleId,
        };
        return viewModel;
    }
}