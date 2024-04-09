namespace UserManagement.Application.Queries.ServiceProvider;

public sealed record GetAllServiceProviderQuery : IRequest<IEnumerable<ServiceProviderDetailsViewModel>>;