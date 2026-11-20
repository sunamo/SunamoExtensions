namespace SunamoExtensions.Utf8Json;

/// <summary>
/// Represents the reflection extensions type.
/// </summary>
public static class ReflectionExtensions
{
    /// <summary>
    /// Is nullable.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The is nullable result.</returns>
    public static bool IsNullable(this System.Reflection.TypeInfo type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(System.Nullable<>);
    }

    /// <summary>
    /// Is public.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The is public result.</returns>
    public static bool IsPublic(this System.Reflection.TypeInfo type)
    {
        return type.IsPublic;
    }

    /// <summary>
    /// Is anonymous.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The is anonymous result.</returns>
    public static bool IsAnonymous(this System.Reflection.TypeInfo type)
    {
        return type.GetCustomAttribute<CompilerGeneratedAttribute>() != null
            && type.Name.Contains("AnonymousType")
            && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
            && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
    }

    // NOTE: This doesn't return all properties in some cases (e.g., when returning from CompilerOptions)
    /// <summary>
    /// Get all properties.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The get all properties result.</returns>
    public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
    {
        return type.GetProperties().ToList();
    }

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
    /// Get all fields.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The get all fields result.</returns>
    public static IEnumerable<FieldInfo> GetAllFields(this Type type)
    {
        return GetAllFieldsCore(type, new HashSet<string>());
    }

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
    /// Is constructed generic type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The is constructed generic type result.</returns>
    public static bool IsConstructedGenericType(this System.Reflection.TypeInfo type)
    {
        return type.AsType().IsConstructedGenericType;
    }

    /// <summary>
    /// Get get method.
    /// </summary>
    /// <param name="propInfo">The prop info.</param>
    /// <returns>The get get method result.</returns>
    public static MethodInfo? GetGetMethod(this PropertyInfo propInfo)
    {
        return propInfo.GetMethod;
    }

    /// <summary>
    /// Get set method.
    /// </summary>
    /// <param name="propInfo">The prop info.</param>
    /// <returns>The get set method result.</returns>
    public static MethodInfo? GetSetMethod(this PropertyInfo propInfo)
    {
        return propInfo.SetMethod;
    }
}
