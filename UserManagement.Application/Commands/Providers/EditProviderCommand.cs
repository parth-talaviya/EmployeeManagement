namespace UserManagement.Application.Commands.Providers;

public sealed record EditProviderCommand(EditProvidersViewModel ProviderDetailsViewModel)
    : IRequest<EditProvidersViewModel>;