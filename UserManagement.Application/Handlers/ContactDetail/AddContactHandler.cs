namespace UserManagement.Application.Handlers.ContactDetail;

public sealed class AddContactHandler : IRequestHandler<CreateContactCommand, CreateContactDetailViewModel>
{
    private readonly IContactDetailService _contactDetailService;

    public AddContactHandler(IContactDetailService contactDetailService)
    {
        _contactDetailService = contactDetailService;
    }

    public async Task<CreateContactDetailViewModel> Handle(CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        var createdContactId = await _contactDetailService
            .CreateContactAsync(request.CreateContactModel, cancellationToken)
            .ConfigureAwait(false);

        var viewModel = new CreateContactDetailViewModel
        {
            Id = createdContactId,
            FirstName = request.CreateContactModel.FirstName,
            MiddleName = request.CreateContactModel.MiddleName,
            LastName = request.CreateContactModel.LastName,
            PhoneNumber = request.CreateContactModel.PhoneNumber,
            Email = request.CreateContactModel.Email
        };

        return viewModel;
    }
}