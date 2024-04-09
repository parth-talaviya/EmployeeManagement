namespace UserManagement.Application.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var parameter = context.Arguments.FirstOrDefault(
            x => x?.GetType()?.Namespace?.Contains("UserManagement.ViewModel") is true);

        if (parameter is null)
        {
            return await next(context).ConfigureAwait(false);
        }

        if (parameter is T t)
        {
            var validationResult = await _validator.ValidateAsync(t).ConfigureAwait(false);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        return await next(context).ConfigureAwait(false);
    }
}