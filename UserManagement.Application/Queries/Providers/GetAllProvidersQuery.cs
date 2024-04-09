namespace UserManagement.Application.Queries.Providers;

public sealed record GetAllProvidersQuery : IRequest<IEnumerable<ProvidersDetailsViewModel>>;