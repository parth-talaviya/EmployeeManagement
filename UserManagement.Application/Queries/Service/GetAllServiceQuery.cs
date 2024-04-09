namespace UserManagement.Application.Queries.Service;

public sealed record GetAllServiceQuery : IRequest<IEnumerable<ServiceDetailsViewModel>>;