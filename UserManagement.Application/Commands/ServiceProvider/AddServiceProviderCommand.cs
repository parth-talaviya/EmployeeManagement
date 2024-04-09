namespace UserManagement.Application.Commands.ServiceProvider;

public sealed record class AddServiceProviderCommand(AddServiceProviderViewModel AddServiceProviderModel)
    : IRequest<AddServiceProviderViewModel>;