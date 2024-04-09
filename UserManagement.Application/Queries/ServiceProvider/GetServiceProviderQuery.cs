namespace UserManagement.Application.Queries.ServiceProvider;

public sealed record GetServiceProviderQuery(int Id) : IRequest<ServiceProviderDetailsViewModel>;