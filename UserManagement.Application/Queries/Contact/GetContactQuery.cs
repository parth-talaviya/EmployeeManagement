namespace UserManagement.Application.Queries.Contact;

public sealed record GetContactQuery(int Id) : IRequest<CreateContactDetailViewModel>;