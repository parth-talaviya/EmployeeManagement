namespace UserManagement.API.Controller.User;

public static class UserController
{
    public static void RegisterUserEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("User").WithTags("User").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll",
            async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var getAllUsersQuery = new GetAllUserQuery();
                var users = await mediator.Send(getAllUsersQuery, cancellationToken).ConfigureAwait(false);

                return Results.Ok(users);
            });

        app.MapGet("/GetSingle",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var getUserByIdQuery = new GetUserByIdQuery(id);
                var user = await mediator.Send(getUserByIdQuery, cancellationToken).ConfigureAwait(false);

                return user != null
                    ? Results.Ok(user)
                    : Results.NotFound($"User with ID {id} not found.");
            });

        Delegate method =
            async (IMediator mediator, CreateUserViewModel userViewModel, CancellationToken cancellationToken) =>
            {
                var createUserCommand = new CreateUserCommand(userViewModel);
                var userCreated = await mediator.Send(createUserCommand, cancellationToken).ConfigureAwait(false);

                return Results.Created("", userCreated);
            };

        app.MapPost("/Create", method).AllowAnonymous().AddValidation(method);

        method = async (IMediator mediator, UserUpdateProfileViewModel userUpdateProfileViewModel,
            CancellationToken cancellationToken) =>
        {
            var editUserCommand = new EditUserCommand(userUpdateProfileViewModel);
            var updatedUserData = await mediator.Send(editUserCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(updatedUserData);
        };

        app.MapPut("/UpdateProfile", method).AddValidation(method);

        method = async (IMediator mediator, UserPasswordUpdateViewModel userPasswordUpdateViewModel,
            CancellationToken cancellationToken) =>
        {
            var editUserPasswordCommand = new EditUserPasswordCommand(userPasswordUpdateViewModel);
            var userPassword = await mediator.Send(editUserPasswordCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(userPassword);
        };

        app.MapPut("/UpdatePassword", method).AddValidation(method);

        app.MapDelete("/Delete",
            async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var deleteUserCommand = new DeleteUserCommand(id);
                var userViewModel = await mediator.Send(deleteUserCommand, cancellationToken).ConfigureAwait(false);

                return userViewModel != null
                    ? Results.Ok(userViewModel)
                    : Results.NotFound($"User with ID {id} not found.");
            });
    }
}