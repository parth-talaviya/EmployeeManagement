namespace UserManagement.Application.Handlers.Country;

public sealed class
    GetAllCountryHandler : IRequestHandler<GetAllCountryQuery, IEnumerable<GetCountryDetailsViewModel>>
{
    private readonly ICountryService _countryService;

    public GetAllCountryHandler(ICountryService countryService)
    {
        _countryService = countryService;
    }

    public async Task<IEnumerable<GetCountryDetailsViewModel>> Handle(GetAllCountryQuery request,
        CancellationToken cancellationToken)
    {
        return await _countryService.GetAllCountryAsync(cancellationToken).ConfigureAwait(false);
    }
}