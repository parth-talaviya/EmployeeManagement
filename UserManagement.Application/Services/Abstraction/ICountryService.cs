namespace UserManagement.Application.Services.Abstraction;

public interface ICountryService
{
    Task<AddCountryDetailsViewModel?> AddCountryAsync(AddCountryDetailsViewModel countryViewModel,
        CancellationToken cancellationToken);

    Task<IEnumerable<GetCountryDetailsViewModel>> GetAllCountryAsync(
        CancellationToken cancellationToken);

    Task<GetCountryDetailsViewModel?> GetCountryAsync(int id, CancellationToken cancellationToken);

    Task<EditCountryDetailsViewModel?> EditCountryAsync(
         EditCountryDetailsViewModel countryDetailsUpdateViewModel, CancellationToken cancellationToken);

    Task<GetCountryDetailsViewModel?> DeleteCountryAsync(int id,
        CancellationToken cancellationToken);
}