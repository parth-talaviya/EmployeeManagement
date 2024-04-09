namespace UserManagement.Application.Handlers.Country;

public sealed class AddCountryHandler : IRequestHandler<AddCountryCommand, AddCountryDetailsViewModel?>
{
    private readonly ICountryService _countryDetailService;

    public AddCountryHandler(ICountryService countryDetailService)
    {
        _countryDetailService = countryDetailService;
    }

    public Task<AddCountryDetailsViewModel?> Handle(AddCountryCommand addCountryCommand,
        CancellationToken cancellationToken)
    {
        return _countryDetailService.AddCountryAsync(addCountryCommand.AddCountryModel, cancellationToken);
    }
}