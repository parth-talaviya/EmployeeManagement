namespace UserManagement.Application.Queries.Country;

public sealed record GetCountryQuery(int Id) : IRequest<GetCountryDetailsViewModel>;