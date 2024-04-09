namespace UserManagement.Application.Handlers.Country;

public sealed class EditCountryHandler : IRequestHandler<EditCountryCommand, EditCountryDetailsViewModel?>
{
    private readonly ICountryService _countryDetailService;

    public EditCountryHandler(ICountryService countryDetailService)
    {
        _countryDetailService = countryDetailService;
    }

    public Task<EditCountryDetailsViewModel?> Handle(EditCountryCommand editCountryCommand,
        CancellationToken cancellationToken)
    {
        return _countryDetailService.EditCountryAsync(editCountryCommand.CountryDetailsViewModel,
            cancellationToken);
    }
}