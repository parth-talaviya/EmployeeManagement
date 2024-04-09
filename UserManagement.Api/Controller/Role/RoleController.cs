namespace UserManagement.API.Controller.Role;

public static class RoleController
{
    public static void RegisterRoleEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Role").WithTags("Role").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllRoleQuery = new GetAllRoleQuery();
                var roles = await mediator.Send(getAllRoleQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(roles);
            });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getRoleByIdQuery = new GetRoleByIdQuery(id);
            var role = await mediator.Send(getRoleByIdQuery, cancellationToken).ConfigureAwait(false);

            return role != null
                ? Results.Ok(role)
                : Results.NotFound($"Role with ID {id} not found.");
        });

        Delegate method =
            async (IMediator mediator, AddRoleViewModel roleViewModel, CancellationToken cancellationToken) =>
            {
                var createRoleCommand = new CreateRoleCommand(roleViewModel);
                var roleCreated = await mediator.Send(createRoleCommand, cancellationToken).ConfigureAwait(false);

                return Results.Created("", roleCreated);
            };

        app.MapPost("/Create", method).RequireAuthorization("AdminPolicy").AddValidation(method);

        method = async (IMediator mediator, UpdateRoleViewModel roleViewModel, CancellationToken cancellationToken) =>
        {
            var editRoleCommand = new EditRoleCommand(roleViewModel);
            var roleUpdated = await mediator.Send(editRoleCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(roleUpdated);
        };

        app.MapPut("/Update", method);

        app.MapDelete("/Delete",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var deleteRoleCommand = new DeleteRoleCommand(id);
                var role = await mediator.Send(deleteRoleCommand, cancellationToken).ConfigureAwait(false);

                return role != null
                    ? Results.Ok(role)
                    : Results.NotFound($"Role with ID {id} not found.");
            });
    }
}