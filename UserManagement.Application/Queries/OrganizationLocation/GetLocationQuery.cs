namespace UserManagement.Application.Queries.OrganizationLocation;

public sealed record GetLocationQuery(int Id) : IRequest<GetAllLocationDetailsViewModel>;