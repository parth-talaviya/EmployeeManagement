namespace UserManagement.Application.Queries.Organization;

public sealed record GetOrganizationByIdQuery(int Id) : IRequest<OrganizationViewModel>;