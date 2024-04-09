namespace UserManagement.Application.Queries.Providers;

public sealed record GetProviderQuery(int Id) : IRequest<ProvidersDetailsViewModel>;