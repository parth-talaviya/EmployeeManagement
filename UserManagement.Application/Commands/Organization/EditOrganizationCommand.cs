namespace UserManagement.Application.Commands.Organization;

public sealed record EditOrganizationCommand(UpdateOrganizationViewModel UpdateOrganizationViewModel)
    : IRequest<UpdateOrganizationViewModel>;