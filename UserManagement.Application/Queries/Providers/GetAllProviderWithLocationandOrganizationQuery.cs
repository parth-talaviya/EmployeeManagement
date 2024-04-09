namespace UserManagement.Application.Queries.Providers;

public sealed record
    GetAllProviderWithLocationandOrganizationQuery : IRequest<
    IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>>;