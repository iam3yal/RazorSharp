namespace RazorSharp.JSInterop.Wrappers;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

using RazorSharp.Core.Contracts;

public abstract class JSModuleWrapper<T> : IJSModuleActivator<T>
    where T : JSModuleWrapper<T>, new()
{
    private readonly ElementReference _element;
    private readonly JSModuleReference? _module;

    public ElementReference Element
    {
        get
            => _element;

        private init
        {
            Precondition.IsNotNull(value.Id);

            _element = value;
        }
    }

    public JSModuleReference Module
    {
        get
            => _module ?? throw new InvalidOperationException("The `Module` property is null.");

        private init
        {
            Precondition.IsNotNull(value);

            _module = value;
        }
    }

    public string Path
        => Module.Path;

    [SuppressMessage("Design", "CA1000:Do not declare static members on generic types",
                     Justification = "Factory method")]
    public static T Create(JSModuleReference moduleRef, ElementReference elementRef)
    {
        Precondition.IsNotNull(moduleRef);
        Precondition.IsNotEmpty(elementRef.Id);

        return new T { Module = moduleRef, Element = elementRef };
    }

    [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize")]
    public ValueTask DisposeAsync()
        => Module.DisposeAsync();
}