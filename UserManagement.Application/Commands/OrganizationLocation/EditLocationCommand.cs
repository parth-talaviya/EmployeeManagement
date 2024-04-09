namespace UserManagement.Application.Commands.OrganizationLocation;

public sealed record EditLocationCommand(UpdateLocationDetailsViewModel LocationDetailsViewModel)
    : IRequest<UpdateLocationDetailsViewModel>;