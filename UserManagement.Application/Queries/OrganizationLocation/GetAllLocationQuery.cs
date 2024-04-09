namespace UserManagement.Application.Queries.OrganizationLocation;

public sealed record GetAllLocationQuery : IRequest<IEnumerable<GetAllLocationDetailsViewModel>>;