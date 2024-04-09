namespace UserManagement.Domain.Attribute;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class RegisterServiceAttribute : System.Attribute
{
    public RegisterServiceAttribute(Type? parentType,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped,
        bool enableLazyLoading = false)
    {
        ParentType = parentType;
        ServiceLifetime = serviceLifetime;
        EnableLazyLoading = enableLazyLoading;
    }

    public Type? ParentType { get; }

    public ServiceLifetime ServiceLifetime { get; }

    public bool EnableLazyLoading { get; }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false)]
public sealed class AsParameterAttribute : System.Attribute
{
    public static readonly Type Type = typeof(AsParameterAttribute);
}