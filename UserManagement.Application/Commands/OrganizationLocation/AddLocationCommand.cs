namespace UserManagement.Application.Commands.OrganizationLocation;

public sealed record class AddLocationCommand(AddLocationDetailsViewModel AddLocationModel)
    : IRequest<AddLocationDetailsViewModel>;