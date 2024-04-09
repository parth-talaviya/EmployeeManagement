namespace UserManagement.Application.Handlers.Country;

public sealed class GetCountryHandler : IRequestHandler<GetCountryQuery, GetCountryDetailsViewModel?>
{
    private readonly ICountryService _countryService;

    public GetCountryHandler(ICountryService countryService)
    {
        _countryService = countryService;
    }

    public Task<GetCountryDetailsViewModel?> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        return _countryService.GetCountryAsync(request.Id, cancellationToken);
    }
}