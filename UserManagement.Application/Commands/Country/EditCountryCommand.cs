namespace UserManagement.Application.Commands.Country;

public sealed record EditCountryCommand(EditCountryDetailsViewModel CountryDetailsViewModel)
    : IRequest<EditCountryDetailsViewModel>;