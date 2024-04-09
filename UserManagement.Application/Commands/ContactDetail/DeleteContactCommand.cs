namespace UserManagement.Application.Commands.ContactDetail;

public sealed record DeleteContactCommand(int Id) : IRequest<CreateContactDetailViewModel?>;