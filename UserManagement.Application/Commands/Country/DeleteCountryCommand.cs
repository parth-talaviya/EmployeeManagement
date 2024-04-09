namespace UserManagement.Application.Commands.Country;

public sealed record DeleteCountryCommand(int Id) : IRequest<GetCountryDetailsViewModel?>;