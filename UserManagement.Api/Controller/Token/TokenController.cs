namespace UserManagement.API.Controller.Token;

public static class TokenController
{
    public static void RegisterTokenEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("RefreshToken").WithTags("RefreshToken");

        app.MapPost("/RefreshToken",
            async (IMediator mediator, RefreshTokenCommand refreshTokenCommand,
                CancellationToken cancellationToken) =>
            {
                var refreshToken = await mediator.Send(refreshTokenCommand, cancellationToken).ConfigureAwait(false);
                return Results.Ok(refreshToken);
            });
    }
}