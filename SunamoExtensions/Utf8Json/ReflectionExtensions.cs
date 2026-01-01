namespace SunamoExtensions.Utf8Json;

/// <summary>
/// Extension methods for Reflection types
/// </summary>
public static class ReflectionExtensions
{
    /// <summary>
    /// Determines whether the type is a nullable value type
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if the type is Nullable&lt;T&gt;</returns>
    public static bool IsNullable(this System.Reflection.TypeInfo type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(System.Nullable<>);
    }

    /// <summary>
    /// Determines whether the type is public
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if the type is public</returns>
    public static bool IsPublic(this System.Reflection.TypeInfo type)
    {
        return type.IsPublic;
    }

    /// <summary>
    /// Determines whether the type is an anonymous type
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if the type is an anonymous type</returns>
    public static bool IsAnonymous(this System.Reflection.TypeInfo type)
    {
        return type.GetCustomAttribute<CompilerGeneratedAttribute>() != null
            && type.Name.Contains("AnonymousType")
            && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
            && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
    }

    /// <summary>
    /// Gets all properties of the type
    /// NOTE: This doesn't return all properties in some cases (e.g., when returning from CompilerOptions)
    /// </summary>
    /// <param name="type">Type to get properties from</param>
    /// <returns>Enumerable of all properties</returns>
    public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
    {
        return type.GetProperties().ToList();
    }

    /// <summary>
    /// Gets all properties including inherited ones (recursive implementation)
    /// </summary>
    static IEnumerable<PropertyInfo> GetAllPropertiesCore(Type type, HashSet<string> nameCheck)
    {
        foreach (var item in type.GetRuntimeProperties())
        {
            if (nameCheck.Add(item.Name))
            {
                yield return item;
            }
        }
        if (type.BaseType != null)
        {
            foreach (var item in GetAllPropertiesCore(type.BaseType, nameCheck))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Gets all fields of the type including inherited ones
    /// </summary>
    /// <param name="type">Type to get fields from</param>
    /// <returns>Enumerable of all fields</returns>
    public static IEnumerable<FieldInfo> GetAllFields(this Type type)
    {
        return GetAllFieldsCore(type, new HashSet<string>());
    }

    /// <summary>
    /// Gets all fields including inherited ones (recursive implementation)
    /// </summary>
    static IEnumerable<FieldInfo> GetAllFieldsCore(Type type, HashSet<string> nameCheck)
    {
        foreach (var item in type.GetRuntimeFields())
        {
            if (nameCheck.Add(item.Name))
            {
                yield return item;
            }
        }
        if (type.BaseType != null)
        {
            foreach (var item in GetAllFieldsCore(type.BaseType, nameCheck))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Determines whether the type is a constructed generic type
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if the type is a constructed generic type</returns>
    public static bool IsConstructedGenericType(this System.Reflection.TypeInfo type)
    {
        return type.AsType().IsConstructedGenericType;
    }

    /// <summary>
    /// Gets the get accessor method for the property
    /// </summary>
    /// <param name="propInfo">Property to get accessor from</param>
    /// <returns>Get accessor method</returns>
    public static MethodInfo? GetGetMethod(this PropertyInfo propInfo)
    {
        return propInfo.GetMethod;
    }

    /// <summary>
    /// Gets the set accessor method for the property
    /// </summary>
    /// <param name="propInfo">Property to get accessor from</param>
    /// <returns>Set accessor method</returns>
    public static MethodInfo? GetSetMethod(this PropertyInfo propInfo)
    {
        return propInfo.SetMethod;
    }
}
