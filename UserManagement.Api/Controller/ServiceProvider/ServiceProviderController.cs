namespace UserManagement.API.Controller.ServiceProvider;

public static class ServiceProviderController
{
    public static void RegisterServiceProviderEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("ServiceProvider").WithTags("ServiceProvider")
            .RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllServiceProviderQuery = new GetAllServiceProviderQuery();
            var serviceprovider =
                await mediator.Send(getAllServiceProviderQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(serviceprovider);
        });

        app.MapGet("/GetSingleRecordFromServiceAndProviderId",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var getServiceProviderByIdQuery = new GetServiceProviderQuery(id);
                var getServiceprovider = await mediator.Send(getServiceProviderByIdQuery, cancellationToken)
                    .ConfigureAwait(false);

                return getServiceprovider;
            });


        Delegate createMethod = async (IMediator mediator, AddServiceProviderViewModel serviceViewModel,
            CancellationToken cancellationToken) =>
        {
            var createServiceProviderCommand = new AddServiceProviderCommand(serviceViewModel);
            var serviceProviderCreated =
                await mediator.Send(createServiceProviderCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", serviceProviderCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteServiceProviderCommand = new DeleteServiceProviderCommand(id);
            var serviceProviderViewModel =
                await mediator.Send(deleteServiceProviderCommand, cancellationToken).ConfigureAwait(false);

            return serviceProviderViewModel != null
                ? Results.Ok(serviceProviderViewModel)
                : Results.NotFound($"Service Provider with ID {id} not found.");
        });
    }
}