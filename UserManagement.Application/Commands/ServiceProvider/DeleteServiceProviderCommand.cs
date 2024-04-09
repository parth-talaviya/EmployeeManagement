namespace UserManagement.Application.Commands.ServiceProvider;

public sealed record DeleteServiceProviderCommand(int Id) : IRequest<ServiceProviderDetailsViewModel?>;