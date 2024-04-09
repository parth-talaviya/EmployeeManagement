namespace UserManagement.Application.Handlers.ContactDetail;

public sealed class DeleteContactHandler : IRequestHandler<DeleteContactCommand, CreateContactDetailViewModel?>
{
    private readonly IContactDetailService _contactDetailService;

    public DeleteContactHandler(IContactDetailService contactDetailService)
    {
        _contactDetailService = contactDetailService;
    }

    public async Task<CreateContactDetailViewModel?> Handle(DeleteContactCommand request,
        CancellationToken cancellationToken)
    {
        return await _contactDetailService.DeleteContactAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}