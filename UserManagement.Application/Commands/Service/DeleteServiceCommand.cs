namespace UserManagement.Application.Commands.Service;

public sealed record DeleteServiceCommand(int Id) : IRequest<ServiceDetailsViewModel?>;