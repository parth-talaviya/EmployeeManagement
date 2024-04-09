namespace UserManagement.Application.Commands.Providers;

public sealed record class AddProviderCommand(AddProvidersViewModel AddProviderModel)
    : IRequest<AddProvidersViewModel>;