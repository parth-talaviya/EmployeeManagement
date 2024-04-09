namespace UserManagement.Application.Commands.Providers;

public sealed record DeleteProviderCommand(int Id) : IRequest<ProvidersDetailsViewModel?>;