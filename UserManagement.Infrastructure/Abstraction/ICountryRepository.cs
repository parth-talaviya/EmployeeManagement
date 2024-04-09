namespace UserManagement.Infrastructure.Abstraction;

public interface ICountryRepository
{
    Task<CountryDetails?> AddCountryDetailAsync(CountryDetails countryDetails,
        CancellationToken cancellationToken);

    Task<IEnumerable<CountryDetails>> GetAllCountryDetailAsync(CancellationToken cancellationToken);

    Task<CountryDetails?> GetCountryDetailAsync(int id, CancellationToken cancellationToken);

    Task<CountryDetails?> EditCountryDetailAsync(CountryDetails countryDetails,
        CancellationToken cancellationToken);

    Task<CountryDetails?> DeleteCountryDetailAsync(int id, CancellationToken cancellationToken);
}
