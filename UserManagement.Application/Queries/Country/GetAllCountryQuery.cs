namespace UserManagement.Application.Queries.Country;

public sealed record GetAllCountryQuery : IRequest<IEnumerable<GetCountryDetailsViewModel>>;