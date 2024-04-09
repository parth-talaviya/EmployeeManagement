namespace UserManagement.Application.Commands.OrganizationLocation;

public sealed record DeleteLocationCommand(int Id) : IRequest<OrganizationLocationDetailsViewModel?>;