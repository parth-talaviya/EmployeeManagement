namespace UserManagement.API.Controller.Contact;

public static class ContactController
{
    public static void RegisterContactEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Contact").WithTags("Contact").RequireAuthorization("AdminPolicy");

        app.MapPost("/GetAll",
            async (IMediator mediator, [FromBody] GetAllContactViewModel getAllContact,
                CancellationToken cancellationToken) =>
            {
                var getAllContactQuery = new GetAllContactQuery(getAllContact);
                var contacts = await mediator.Send(getAllContactQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(contacts);
            });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getContactByIdQuery = new GetContactQuery(id);
            var getContact = await mediator.Send(getContactByIdQuery, cancellationToken).ConfigureAwait(false);

            return getContact;
        });

        Delegate createMethod = async (IMediator mediator, CreateContactDetailViewModel contactViewModel,
            CancellationToken cancellationToken) =>
        {
            var createContactCommand = new CreateContactCommand(contactViewModel);
            var contactCreated = await mediator.Send(createContactCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", contactCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);

        Delegate updateMethod = async (IMediator mediator, UpdateContactViewModel contactUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editContactCommand = new EditContactCommand(contactUpdateViewModel);
            var updatedContactData = await mediator.Send(editContactCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(updatedContactData);
        };

        app.MapPut("/Update", updateMethod).AddValidation(updateMethod);

        app.MapDelete("/Delete", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var deleteContactCommand = new DeleteContactCommand(id);
            var contactViewModel = await mediator.Send(deleteContactCommand, cancellationToken).ConfigureAwait(false);

            return contactViewModel != null
                ? Results.Ok(contactViewModel)
                : Results.NotFound($"Contact with ID {id} not found.");
        });
    }
}