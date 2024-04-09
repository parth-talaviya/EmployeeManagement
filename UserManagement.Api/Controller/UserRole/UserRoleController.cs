namespace UserManagement.API.Controller.UserRole;

public static class UserRoleController
{
    public static void RegisterUserRoleEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("UserRole").WithTags("UserRole").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetSingle",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var getUserRoleByIdQuery = new GetUserRoleByIdQuery(id);
                var userRole = await mediator.Send(getUserRoleByIdQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(userRole);
            });

        Delegate method = async (IMediator mediator, AddUserRoleViewModel userRoleViewModel,
            CancellationToken cancellationToken) =>
        {
            var createUserRoleCommand = new CreateUserRoleCommand(userRoleViewModel);
            var userRoleCreated = await mediator.Send(createUserRoleCommand, cancellationToken).ConfigureAwait(false);

            return Results.Created("", userRoleCreated);
        };

        app.MapPost("/Create", method).AddValidation(method);

        app.MapDelete("/Delete",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var deleteUserRoleCommand = new DeleteUserRoleCommand(id);
                var userRole = await mediator.Send(deleteUserRoleCommand, cancellationToken).ConfigureAwait(false);

                return userRole != null
                    ? Results.Ok(userRole)
                    : Results.NotFound($"User Role with ID {id} not found.");
            });
    }
}