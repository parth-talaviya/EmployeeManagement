namespace UserManagement.Application.Queries.Service;

public sealed record
    GetAllServicewithLocationAndOrganizationQuery : IRequest<
    IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>;