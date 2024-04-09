namespace UserManagement.Application.Handlers.ContactDetail;

public sealed class EditContactHandler : IRequestHandler<EditContactCommand, UpdateContactViewModel?>
{
    private readonly IContactDetailService _contactDetailService;

    public EditContactHandler(IContactDetailService contactDetailService)
    {
        _contactDetailService = contactDetailService;
    }

    public Task<UpdateContactViewModel?> Handle(EditContactCommand editContactCommand,
        CancellationToken cancellationToken)
    {
        return _contactDetailService.EditContactAsync(editContactCommand.ContactDetailsViewModel, cancellationToken);
    }
}