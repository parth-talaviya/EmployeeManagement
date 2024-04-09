namespace UserManagement.Application.GlobalExceptionHandler;

public sealed class BadRequestExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var errorMessage = new
        {
            title = "Internal Server Error"
        };

        await httpContext.Response
            .WriteAsJsonAsync(errorMessage, cancellationToken).ConfigureAwait(false);

        Log.Error("Exception occurred: {Exception}\n", exception);

        return true;
    }
}