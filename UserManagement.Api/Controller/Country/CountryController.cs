namespace UserManagement.API.Controller.Country;

public static class CountryController
{
    public static void RegisterCountryEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Country").WithTags("Country").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllCountryQuery = new GetAllCountryQuery();
            var country = await mediator.Send(getAllCountryQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(country);
        });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getCountryByIdQuery = new GetCountryQuery(id);
            var getCountry = await mediator.Send(getCountryByIdQuery, cancellationToken).ConfigureAwait(false);

            return getCountry;
        });

        Delegate createMethod = async (IMediator mediator, AddCountryDetailsViewModel countryViewModel,
            CancellationToken cancellationToken) =>
        {
            var createCountryCommand = new AddCountryCommand(countryViewModel);
            var countryCreated = await mediator.Send(createCountryCommand, cancellationToken).ConfigureAwait(false);

            return countryCreated != null
                ? Results.Ok(countryCreated)
                : Results.NotFound($"Please Enter Unique Value");
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        Delegate updateMethod = async (IMediator mediator, EditCountryDetailsViewModel countryUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editCountryCommand = new EditCountryCommand(countryUpdateViewModel);
            var updatedCountryData = await mediator.Send(editCountryCommand, cancellationToken).ConfigureAwait(false);

            return updatedCountryData != null
                    ? Results.Ok(updatedCountryData)
                    : Results.NotFound($"Country ID not found.");
        };

        app.MapPut("/Update", updateMethod).AddValidation(updateMethod);


        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteCountryCommand = new DeleteCountryCommand(id);
            var countryViewModel = await mediator.Send(deleteCountryCommand, cancellationToken).ConfigureAwait(false);

            return countryViewModel != null
                ? Results.Ok(countryViewModel)
                : Results.NotFound($"Country ID not found.");
        });
    }
}