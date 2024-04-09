namespace UserManagement.Application.Handlers.ContactDetail;

public sealed class
    GetAllContactHandler : IRequestHandler<GetAllContactQuery, IEnumerable<CreateContactDetailViewModel>>
{
    private readonly IContactDetailService _contactDetailService;

    public GetAllContactHandler(IContactDetailService contactDetailService)
    {
        _contactDetailService = contactDetailService;
    }

    public Task<IEnumerable<CreateContactDetailViewModel>> Handle(GetAllContactQuery request,
        CancellationToken cancellationToken)
    {
        return _contactDetailService.GetAllContactAsync(request.GetAllContactViewModel, cancellationToken);
    }
}