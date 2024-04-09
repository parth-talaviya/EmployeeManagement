namespace UserManagement.Infrastructure.Extension;

internal static class ParameterExtension
{
    private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public;
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyMapInfo = new();

    internal static void AddParameters<T>(this DynamicParameters dynamicParameters, T? @object) where T : class
    {
        if (@object is null)
        {
            return;
        }

        var parameters = GetParameters(@object);

        foreach (var parameter in parameters)
        {
            dynamicParameters.Add(parameter.Name, parameter.Value, dbType: parameter.DbType);
        }
    }

    private static IEnumerable<ParameterContainer> GetParameters<T>(T @object)
    {
        var type = @object!.GetType();

        PropertyInfo[] propertyInfo = GetOrAddParameters(type);

        foreach (var item in propertyInfo)
        {
            yield return new ParameterContainer(item.Name, item.GetValue(@object),
                ConvertToType(item.PropertyType.Name));
        }
    }

    private static PropertyInfo[] GetOrAddParameters(Type type)
    {
        if (PropertyMapInfo.TryGetValue(type, out PropertyInfo[]? propertyInfo))
        {
            return propertyInfo;
        }

        var isFullParameterised = type.IsDefined(AsParameterAttribute.Type, false);

        propertyInfo = isFullParameterised ||
                       (type.Name.Contains("AnonymousType", StringComparison.InvariantCultureIgnoreCase) is true)
            ? type.GetProperties(Flags)
            : type.GetProperties(Flags)
                .Where(x => x.IsDefined(AsParameterAttribute.Type))
                .ToArray();

        PropertyMapInfo.TryAdd(type, propertyInfo);

        return propertyInfo;
    }

    private static DbType ConvertToType(string typeName) => typeName switch
    {
        nameof(DbType.String) => DbType.String,
        nameof(DbType.Int16) => DbType.Int16,
        nameof(DbType.Int32) => DbType.Int32,
        nameof(DbType.Int64) => DbType.Int64,
        nameof(DbType.Byte) => DbType.Byte,
        nameof(DbType.Double) => DbType.Double,
        nameof(DbType.Decimal) => DbType.Decimal,
        nameof(DbType.DateTime) => DbType.DateTime2,
        nameof(DbType.Guid) => DbType.Guid,
        _ => DbType.Object
    };

    private readonly struct ParameterContainer(string name, object? value, DbType dbType)
    {
        public string Name { get; } = name;

        public object? Value { get; } = value;

        public DbType DbType { get; } = dbType;
    }
}