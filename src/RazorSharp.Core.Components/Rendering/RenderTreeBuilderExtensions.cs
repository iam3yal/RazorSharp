namespace RazorSharp.Core.Components.Rendering;

using System.Globalization;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

public static class RenderTreeBuilderExtensions
{
    private static readonly EventCallbackFactory EventCallbackFactory = new ();

    public static void AddAttributeIfNotNullOrEmpty(this RenderTreeBuilder builder,
                                                    int sequence,
                                                    string name,
                                                    string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            builder.AddAttribute(sequence, name, value);
        }
    }

    public static void AddBind(this RenderTreeBuilder builder,
                               int sequence,
                               string attribute,
                               object receiver,
                               Action<string?> setter,
                               string existingValue,
                               CultureInfo? culture = null)
        => builder.AddAttribute(sequence,
                                attribute,
                                EventCallbackFactory.CreateBinder(receiver, setter, existingValue, culture));

    public static void AddEvent(this RenderTreeBuilder builder,
                                int sequence,
                                string @event,
                                object receiver,
                                Func<Task> callback)
        => builder.AddAttribute(sequence,
                                @event,
                                EventCallbackFactory.Create(receiver, callback));

    public static void AddEvent<TValue>(this RenderTreeBuilder builder,
                                        int sequence,
                                        string @event,
                                        object receiver,
                                        Func<TValue, Task> callback)
        => builder.AddAttribute(sequence,
                                @event,
                                EventCallbackFactory.Create(receiver, callback));
}