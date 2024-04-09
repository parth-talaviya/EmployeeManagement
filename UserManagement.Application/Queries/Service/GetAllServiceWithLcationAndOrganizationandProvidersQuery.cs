namespace UserManagement.Application.Queries.Service;

public sealed record
    GetAllServiceWithLcationAndOrganizationandProvidersQuery : IRequest<
    IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>;