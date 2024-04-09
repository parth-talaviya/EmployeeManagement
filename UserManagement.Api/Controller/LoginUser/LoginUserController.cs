namespace UserManagement.API.Controller.LoginUser;

public static class LoginUserController
{
    public static void RegisterLoginUserEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("LoginUser").WithTags("UserLogin");

        app.MapPost("/LoginUser", async (IMediator mediator, LoginUserCommand loginUserCommand, CancellationToken cancellationToken) =>
        {
            var userViewModel = await mediator.Send(loginUserCommand, cancellationToken).ConfigureAwait(false);

            if (userViewModel == null || userViewModel.Token == null || userViewModel.RefreshToken == null)
            {
                return Results.BadRequest("Invalid username or password. Please enter valid credentials.");
            }

            return Results.Ok(new { userViewModel.Token, userViewModel.RefreshToken });
        });
    }
}