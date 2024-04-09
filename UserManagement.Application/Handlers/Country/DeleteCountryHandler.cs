namespace UserManagement.Application.Handlers.Country;

public sealed class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, GetCountryDetailsViewModel?>
{
    private readonly ICountryService _countryDetailService;

    public DeleteCountryHandler(ICountryService countryDetailService)
    {
        _countryDetailService = countryDetailService;
    }

    public async Task<GetCountryDetailsViewModel?> Handle(DeleteCountryCommand request,
        CancellationToken cancellationToken)
    {
        return await _countryDetailService.DeleteCountryAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}