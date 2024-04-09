namespace UserManagement.Application.Queries.Contact;

public sealed record GetAllContactQuery(GetAllContactViewModel GetAllContactViewModel)
    : IRequest<IEnumerable<CreateContactDetailViewModel>>;