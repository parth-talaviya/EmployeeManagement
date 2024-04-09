namespace UserManagement.Application.Commands.ContactDetail;

public sealed record EditContactCommand(UpdateContactViewModel ContactDetailsViewModel)
    : IRequest<UpdateContactViewModel>;