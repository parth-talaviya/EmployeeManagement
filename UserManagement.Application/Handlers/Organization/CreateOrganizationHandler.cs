namespace UserManagement.Application.Handlers.Organization;

public sealed class CreateOrganizationHandler : IRequestHandler<CreateOrganizationCommand, AddOrganizationViewModel>
{
    private readonly IOrganizationService _organizationService;

    public CreateOrganizationHandler(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public async Task<AddOrganizationViewModel> Handle(CreateOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var createdID = await _organizationService
            .AddOrganizationAsync(request.OrganizationViewModel, cancellationToken).ConfigureAwait(false);


        var viewModel = new AddOrganizationViewModel
        {
            Id = createdID,
            Name = request.OrganizationViewModel.Name,
        };

        return viewModel;
    }
}