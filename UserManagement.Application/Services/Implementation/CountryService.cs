namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(ICountryService))]

public sealed class CountryService : ICountryService
{
    private readonly ICountryRepository _countryDetailsRepository;
    private readonly IMapper _mapper;

    public CountryService(ICountryRepository countryRegisterRepository,
        IMapper mapper)
    {
        _countryDetailsRepository = countryRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddCountryDetailsViewModel?> AddCountryAsync(AddCountryDetailsViewModel countryViewModel,
     CancellationToken cancellationToken)
    {
        var countryDetails = _mapper.Map<AddCountryDetailsViewModel, CountryDetails>(countryViewModel);
        var insertedCountryDetails = await _countryDetailsRepository.AddCountryDetailAsync(countryDetails, cancellationToken)
            .ConfigureAwait(false);
        var resultViewModel = _mapper.Map<CountryDetails?, AddCountryDetailsViewModel>(insertedCountryDetails);

        return resultViewModel != null
        ? _mapper.Map<AddCountryDetailsViewModel>(resultViewModel)
        : null;
    }

    public async Task<IEnumerable<GetCountryDetailsViewModel>> GetAllCountryAsync(
        CancellationToken cancellationToken)
    {
        var getAllCountryDetail = await _countryDetailsRepository
            .GetAllCountryDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetCountryDetailsViewModel>>(getAllCountryDetail) ??
               Enumerable.Empty<GetCountryDetailsViewModel>();
    }

    public async Task<GetCountryDetailsViewModel?> GetCountryAsync(int id, CancellationToken cancellationToken)
    {
        var getCountry = await _countryDetailsRepository.GetCountryDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getCountry != null ? _mapper.Map<GetCountryDetailsViewModel>(getCountry) : null;
    }

    public async Task<EditCountryDetailsViewModel?> EditCountryAsync(
         EditCountryDetailsViewModel countryDetailsUpdateViewModel, CancellationToken cancellationToken)
    {
        var editCountry = _mapper.Map<EditCountryDetailsViewModel, CountryDetails>(countryDetailsUpdateViewModel);
        var updateCountry = await _countryDetailsRepository
            .EditCountryDetailAsync(editCountry, cancellationToken)
            .ConfigureAwait(false);

        return updateCountry != null
            ? _mapper.Map<CountryDetails, EditCountryDetailsViewModel>(updateCountry)
            : null;
    }

    public async Task<GetCountryDetailsViewModel?> DeleteCountryAsync(int id,
        CancellationToken cancellationToken)
    {
        var deleteCountry = await _countryDetailsRepository
            .DeleteCountryDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteCountry != null ? _mapper.Map<GetCountryDetailsViewModel>(deleteCountry) : null;
    }
}