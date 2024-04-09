namespace UserManagement.Application.Commands.ContactDetail;

public sealed record class CreateContactCommand(CreateContactDetailViewModel CreateContactModel)
    : IRequest<CreateContactDetailViewModel>;