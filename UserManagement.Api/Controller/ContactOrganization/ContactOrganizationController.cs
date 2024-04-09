namespace UserManagement.API.Controller.ContactOrganization;

public static class ContactOrganizationController
{
    public static void RegisterContactOrganizationEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("ContactOrganization").WithTags("ContactOrganization")
            .RequireAuthorization("AdminPolicy");

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getContactOrganizationQuery = new GetContactOrganizationQuery(id);
            var contactOrganization =
                await mediator.Send(getContactOrganizationQuery, cancellationToken).ConfigureAwait(false);

            return contactOrganization.Any()
                ? Results.Ok(contactOrganization)
                : Results.NotFound($"Contact Organization with ID {id} not found.");
        });

        Delegate createMethod = async (IMediator mediator, AddContactOrganizationViewModel contactOrganizationViewModel,
            CancellationToken cancellationToken) =>
        {
            var createContactOrganizationCommand = new CreateContactOrganizationCommand(contactOrganizationViewModel);
            var contactOrganizationCreated = await mediator.Send(createContactOrganizationCommand, cancellationToken)
                .ConfigureAwait(false);

            return Results.Created("", contactOrganizationCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteContactOrganizationCommand = new DeleteContactOrganizationCommand(id);
            var contactOrganization = await mediator.Send(deleteContactOrganizationCommand, cancellationToken)
                .ConfigureAwait(false);

            return contactOrganization != null
                ? Results.Ok(contactOrganization)
                : Results.NotFound($"Contact Organization with ID {id} not found.");
        });
    }
}