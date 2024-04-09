namespace UserManagement.API.Controller.Service;

public static class ServiceController
{
    public static void RegisterServiceEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Service").WithTags("Service").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllServiceQuery = new GetAllServiceQuery();
            var services = await mediator.Send(getAllServiceQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(services);
        });

        app.MapGet("/GetAllServicewithOrganizationAndLocation",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllServiceQuery = new GetAllServicewithLocationAndOrganizationQuery();
                var services = await mediator.Send(getAllServiceQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(services);
            });

        app.MapGet("/GetAllServicewithOrganizationAndLocationAndProviders",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllServiceQuery = new GetAllServiceWithLcationAndOrganizationandProvidersQuery();
                var services = await mediator.Send(getAllServiceQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(services);
            });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getServiceByIdQuery = new GetServiceQuery(id);
            var getService = await mediator.Send(getServiceByIdQuery, cancellationToken).ConfigureAwait(false);

            return getService;
        });


        Delegate createMethod = async (IMediator mediator, AddServiceViewModel serviceViewModel,
            CancellationToken cancellationToken) =>
        {
            var createServiceCommand = new AddServiceCommand(serviceViewModel);
            var serviceCreated = await mediator.Send(createServiceCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", serviceCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        Delegate updateMethod = async (IMediator mediator, EditServiceViewModel serviceUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editServiceCommand = new EditServiceCommand(serviceUpdateViewModel);
            var updatedServiceData = await mediator.Send(editServiceCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(updatedServiceData);
        };

        app.MapPut("/Update", updateMethod).AddValidation(updateMethod);


        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteServiceCommand = new DeleteServiceCommand(id);
            var serviceViewModel = await mediator.Send(deleteServiceCommand, cancellationToken).ConfigureAwait(false);

            return serviceViewModel != null
                ? Results.Ok(serviceViewModel)
                : Results.NotFound($"Service with ID {id} not found.");
        });
    }
}