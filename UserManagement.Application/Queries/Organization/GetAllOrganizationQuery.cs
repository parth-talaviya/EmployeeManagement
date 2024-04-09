namespace UserManagement.Application.Queries.Organization;

public sealed record GetAllOrganizationQuery : IRequest<IEnumerable<OrganizationViewModel>>;