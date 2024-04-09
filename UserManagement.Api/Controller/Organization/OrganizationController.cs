namespace UserManagement.API.Controller.Organization;

public static class OrganizationController
{
    public static void RegisterOrganizationEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Organization").WithTags("Organization").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllOrganizationQuery = new GetAllOrganizationQuery();
                var organizationNames =
                    await mediator.Send(getAllOrganizationQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(organizationNames);
            });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getOrganizationByIdQuery = new GetOrganizationByIdQuery(id);
            var organization = await mediator.Send(getOrganizationByIdQuery, cancellationToken).ConfigureAwait(false);

            return organization != null
                ? Results.Ok(organization)
                : Results.NotFound($"Contact Organization with ID {id} not found.");
        });

        Delegate method = async (IMediator mediator, AddOrganizationViewModel organizationViewModel,
            CancellationToken cancellationToken) =>
        {
            var createOrganizationCommand = new CreateOrganizationCommand(organizationViewModel);
            var organizationCreated =
                await mediator.Send(createOrganizationCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", organizationCreated);
        };

        app.MapPost("/Create", method).RequireAuthorization("AdminPolicy").AddValidation(method);

        method = async (IMediator mediator, UpdateOrganizationViewModel organizationViewModel,
            CancellationToken cancellationToken) =>
        {
            var editorganizationCommand = new EditOrganizationCommand(organizationViewModel);
            var organizationUpdated =
                await mediator.Send(editorganizationCommand, cancellationToken).ConfigureAwait(false);

            return organizationUpdated != null
                    ? Results.Ok(organizationUpdated)
                    : Results.NotFound($"Organization ID not found.");
        };

        app.MapPut("/Update", method).AddValidation(method);

        app.MapDelete("/Delete",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var deleteOrganizationCommand = new DeleteOrganizationCommand(id);
                var organization =
                    await mediator.Send(deleteOrganizationCommand, cancellationToken).ConfigureAwait(false);

                return organization != null
                    ? Results.Ok(organization)
                    : Results.NotFound($" Organization with ID {id} not found.");
            });
    }
}