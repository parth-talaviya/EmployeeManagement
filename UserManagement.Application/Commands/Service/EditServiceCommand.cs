namespace UserManagement.Application.Commands.Service;

public sealed record EditServiceCommand(EditServiceViewModel ServiceDetailsViewModel)
    : IRequest<EditServiceViewModel>;