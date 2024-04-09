namespace UserManagement.API.Controller.Provider;

public static class ProviderController
{
    public static void RegisterProviderEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Provider").WithTags("Provider").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllProvidersQuery = new GetAllProvidersQuery();
            var providers = await mediator.Send(getAllProvidersQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(providers);
        });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getProviderByIdQuery = new GetProviderQuery(id);
            var getProvider = await mediator.Send(getProviderByIdQuery, cancellationToken).ConfigureAwait(false);

            return getProvider;
        });

        app.MapGet("/GetAllProvidersWithServiceLocationAndOrganization",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllProvidersQuery = new GetAllProvidersWithServiceLocationAndOrganizationQuery();
                var providers = await mediator.Send(getAllProvidersQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(providers);
            });

        app.MapGet("/GetAllProvidersWithLocationAndOrganization",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllProvidersQuery = new GetAllProviderWithLocationandOrganizationQuery();
                var providers = await mediator.Send(getAllProvidersQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(providers);
            });


        Delegate createMethod = async (IMediator mediator, AddProvidersViewModel providerViewModel,
            CancellationToken cancellationToken) =>
        {
            var createProviderCommand = new AddProviderCommand(providerViewModel);
            var providerCreated = await mediator.Send(createProviderCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", providerCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        Delegate updateMethod = async (IMediator mediator, EditProvidersViewModel providerUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editProviderCommand = new EditProviderCommand(providerUpdateViewModel);
            var updatedProviderData = await mediator.Send(editProviderCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(updatedProviderData);
        };

        app.MapPut("/Update", updateMethod).AddValidation(updateMethod);


        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteProviderCommand = new DeleteProviderCommand(id);
            var providerViewModel = await mediator.Send(deleteProviderCommand, cancellationToken).ConfigureAwait(false);

            return providerViewModel != null
                ? Results.Ok(providerViewModel)
                : Results.NotFound($"Provider with ID {id} not found.");
        });
    }
}