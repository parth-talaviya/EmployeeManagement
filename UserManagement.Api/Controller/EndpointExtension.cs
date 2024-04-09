namespace UserManagement.API.Controller;

public static class EndpointExtension
{
    public static void RegisterEndpoints(this WebApplication application)
    {
        application.RegisterUserEndpoints();
        application.RegisterRoleEndpoints();
        application.RegisterUserRoleEndpoints();
        application.RegisterLoginUserEndpoints();
        application.RegisterTokenEndpoints();
        application.RegisterContactOrganizationEndpoints();
        application.RegisterOrganizationEndpoints();
        application.RegisterContactEndpoints();
        application.RegisterLocationEndpoints();
        application.RegisterProviderEndpoints();
        application.RegisterServiceEndpoints();
        application.RegisterServiceProviderEndpoints();
        application.RegisterBookingEndpoints();
        application.RegisterCountryEndpoints();
    }
}

public static class ValidationApplier
{
    private static readonly MethodInfo MethodToCall = typeof(EndpointFilterExtensions)
        .GetMethods(BindingFlags.Static | BindingFlags.Public)
        .First(x => x.Name == nameof(EndpointFilterExtensions.AddEndpointFilter) && x.IsGenericMethod
            && x.ReturnType == typeof(RouteHandlerBuilder));

    public static Delegate AddValidation(this RouteHandlerBuilder routeHandlerBuilder, Delegate @delegate)
    {
        var validationType = @delegate.GetMethodInfo().GetParameters()
            .FirstOrDefault(x => x.ParameterType.Namespace?.Contains("UserManagement.ViewModel") is true
                                 && x.ParameterType.IsClass);

        if (validationType is null)
        {
            return @delegate;
        }

        var mainParameterType = typeof(ValidationFilter<>);
        mainParameterType = mainParameterType.MakeGenericType(validationType.ParameterType);

        MethodToCall.MakeGenericMethod(mainParameterType)
            .CreateDelegate<Func<RouteHandlerBuilder, RouteHandlerBuilder>>()(routeHandlerBuilder);

        return @delegate;
    }
}