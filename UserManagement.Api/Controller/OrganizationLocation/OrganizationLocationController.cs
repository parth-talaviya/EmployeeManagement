namespace UserManagement.API.Controller.OrganizationLocation;

public static class OrganizationLocationController
{
    public static void RegisterLocationEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Location").WithTags("Location").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllUsersQuery = new GetAllLocationQuery();
            var users = await mediator.Send(getAllUsersQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(users);
        });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getContactByIdQuery = new GetLocationQuery(id);
            var getContact = await mediator.Send(getContactByIdQuery, cancellationToken).ConfigureAwait(false);

            return getContact;
        });


        Delegate createMethod = async (IMediator mediator, AddLocationDetailsViewModel locationViewModel,
            CancellationToken cancellationToken) =>
        {
            var createContactCommand = new AddLocationCommand(locationViewModel);
            var contactCreated = await mediator.Send(createContactCommand, cancellationToken).ConfigureAwait(false);

            return contactCreated != null
                ? Results.Ok(contactCreated)
                : Results.NotFound($"Please Enter Valid Details"); 
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        Delegate updateMethod = async (IMediator mediator, UpdateLocationDetailsViewModel locationUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editLocationCommand = new EditLocationCommand(locationUpdateViewModel);
            var updatedLocationData = await mediator.Send(editLocationCommand, cancellationToken).ConfigureAwait(false);

            return  updatedLocationData != null
                ? Results.Ok(updatedLocationData)
                : Results.NotFound($"Location ID not found."); 
        };

        app.MapPut("/Update", updateMethod).AddValidation(updateMethod);


        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteContactCommand = new DeleteLocationCommand(id);
            var locationViewModel = await mediator.Send(deleteContactCommand, cancellationToken).ConfigureAwait(false);

            return locationViewModel != null
                ? Results.Ok(locationViewModel)
                : Results.NotFound($"Location with ID {id} not found.");
        });
    }
}