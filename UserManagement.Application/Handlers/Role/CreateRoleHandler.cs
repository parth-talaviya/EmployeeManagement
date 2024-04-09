namespace UserManagement.Application.Handlers.Role;

public sealed class CreateRoleHandler : IRequestHandler<CreateRoleCommand, AddRoleViewModel>
{
    private readonly IRoleService _roleService;

    public CreateRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<AddRoleViewModel> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var createdID = await _roleService.AddRoleAsync(request.AddRoleViewModel, cancellationToken)
            .ConfigureAwait(false);
        var viewModel = new AddRoleViewModel
        {
            Id = createdID,
            Name = request.AddRoleViewModel.Name
        };
        return viewModel;
    }
}