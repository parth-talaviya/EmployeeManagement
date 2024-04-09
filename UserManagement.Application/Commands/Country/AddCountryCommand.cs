namespace UserManagement.Application.Commands.Country;

public sealed record class AddCountryCommand(AddCountryDetailsViewModel AddCountryModel)
    : IRequest<AddCountryDetailsViewModel>;