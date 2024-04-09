namespace UserManagement.Application.Handlers.ContactDetail;

public sealed class GetContactHandler : IRequestHandler<GetContactQuery, CreateContactDetailViewModel?>
{
    private readonly IContactDetailService _contactDetailService;

    public GetContactHandler(IContactDetailService contactDetailService)
    {
        _contactDetailService = contactDetailService;
    }

    public Task<CreateContactDetailViewModel?> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        return _contactDetailService.GetContactAsync(request.Id, cancellationToken);
    }
}