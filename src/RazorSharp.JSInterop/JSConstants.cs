namespace RazorSharp.JSInterop;

public static class JSConstants
{
    public static string CreateInstanceIdentifier<T>()
        => CreateStaticIdentifier<T>("createInstance");

    public static string CreateStaticIdentifier<T>(ReadOnlySpan<char> name)
    {
        var type = typeof(T);
        var typeName = type.Name.AsSpan();

        if (type.IsGenericType)
        {
            var index = typeName.LastIndexOf('`');
            typeName = typeName[..index];
        }

        return $"{typeName}.{name}";
    }
}