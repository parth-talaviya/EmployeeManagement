namespace UserManagement.Application.Queries.Service;

public sealed record GetServiceQuery(int Id) : IRequest<ServiceDetailsViewModel>;