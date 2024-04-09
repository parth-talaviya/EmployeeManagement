namespace UserManagement.Application.Handlers.ContactOrganization;

public sealed class
    CreateContactOrganizationHandler : IRequestHandler<CreateContactOrganizationCommand,
    AddContactOrganizationViewModel>
{
    private readonly IContactOrganizationService _contactOrganizationService;

    public CreateContactOrganizationHandler(IContactOrganizationService contactOrganizationService)
    {
        _contactOrganizationService = contactOrganizationService;
    }

    public async Task<AddContactOrganizationViewModel> Handle(CreateContactOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var createdId = await _contactOrganizationService
            .AddContactOrganizationAsync(request.AddContactOrganizationViewModel, cancellationToken)
            .ConfigureAwait(false);

        var viewModel = new AddContactOrganizationViewModel
        {
            Id = createdId,
            ContactId = request.AddContactOrganizationViewModel.ContactId,
            OrganizationId = request.AddContactOrganizationViewModel.OrganizationId
        };

        return viewModel;
    }
}