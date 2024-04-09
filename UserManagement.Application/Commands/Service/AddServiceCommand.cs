namespace UserManagement.Application.Commands.Service;

public sealed record class AddServiceCommand(AddServiceViewModel AddServiceModel)
    : IRequest<AddServiceViewModel>;