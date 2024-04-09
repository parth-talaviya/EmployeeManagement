namespace UserManagement.Application.Queries.Providers;

public sealed record
    GetAllProvidersWithServiceLocationAndOrganizationQuery : IRequest<
    IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>>;