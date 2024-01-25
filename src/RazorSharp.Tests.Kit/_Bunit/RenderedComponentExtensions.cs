namespace RazorSharp.Tests.Kit._Bunit;

using System.Linq.Expressions;

using Bunit;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using RazorSharp.Core.Contracts;

public static class RenderedComponentExtensions
{
    public static async Task<EventInfo> BindAndFireEvent<TComponent, T>(this IRenderedComponent<TComponent> component,
                                                                        Expression<Func<TComponent, T>> eventProperty,
                                                                        string cssSelector,
                                                                        bool rerender = false)
        where TComponent : class, IComponent
    {
        Precondition.IsNotNull(component);
        Precondition.IsNotNull(eventProperty);

        var (propertyName, propertyType) = eventProperty.Body switch
        {
            MemberExpression m                              => (m.Member.Name, eventProperty.Body.Type),
            UnaryExpression { Operand: MemberExpression m } => (m.Member.Name, eventProperty.Body.Type),
            _                                               => throw new NotImplementedException()
        };

        var componentType = typeof(TComponent);
        var property = componentType.GetProperty(propertyName);

        Postcondition.IsNotNull(property);

        var eventInfo = new EventInfo(propertyName);

        object? eventHandler;

        if (propertyType is { IsGenericType: true, GenericTypeArguments: var propertyTypeArgs })
        {
            string? methodName = null;
            Type? eventArgType = null;

            switch (propertyType.Name)
            {
                case var s when s.StartsWith("EventCallback`1", StringComparison.Ordinal):
                {
                    methodName = nameof(EventHandlerFactory.CreateEventCallbackHandler1);
                    eventArgType = propertyTypeArgs[0];
                    break;
                }
                case var s when s.StartsWith("Func`2", StringComparison.Ordinal)
                                && propertyTypeArgs is [var arg1, var arg2]:
                {
                    if (arg2 == typeof(Task))
                    {
                        methodName = nameof(EventHandlerFactory.CreateEventFuncHandler0);
                        eventArgType = arg1;
                    }
                    else if (arg2 == typeof(ValueTask))
                    {
                        methodName = nameof(EventHandlerFactory.CreateEventFuncHandler1);
                        eventArgType = arg1;
                    }

                    break;
                }
            }

            if (methodName is null)
            {
                throw new InvalidOperationException("No event handler method was matched.");
            }

            if (eventArgType is null)
            {
                throw new InvalidOperationException($"The generic type '{propertyType}' is not supported.");
            }

            var createMethod = typeof(EventHandlerFactory).GetMethod(methodName);
            var genericCreateMethod = createMethod?.MakeGenericMethod(eventArgType);

            eventHandler = genericCreateMethod?.Invoke(null, new object?[] { eventInfo });
        }
        else
        {
            eventHandler = EventHandlerFactory.CreateEventCallbackHandler(eventInfo);
        }

        property.SetValue(component.Instance, eventHandler);

        if (rerender)
        {
            // NOTE: Sometimes it's required to rerender the component again because when bUnit renders it the first time the event handler might not be attached or set due to a condition or a guard so in this case it's necessary to rerender the component after we set the property with our fake handler.
            component.Render();
        }

        var element = component.Find(cssSelector);

        switch (propertyName)
        {
            case "OnInvalid":
                await element.InvalidAsync();
                break;
            case "OnActivate":
                await element.ActivateAsync();
                break;
            case "OnBeforeActivate":
                await element.BeforeActivateAsync();
                break;
            case "OnDeactivate":
                await element.DeactivateAsync();
                break;
            case "OnBeforeDeactivate":
                await element.BeforeDeactivateAsync();
                break;
            case "OnFocus":
                await element.FocusAsync(new FocusEventArgs { Type = "focus" });
                break;
            case "OnFocusIn":
                await element.FocusInAsync(new FocusEventArgs { Type = "focusin" });
                break;
            case "OnFocusOut":
                await element.FocusOutAsync(new FocusEventArgs { Type = "focusout" });
                break;
            case "OnBlur":
                await element.BlurAsync(new FocusEventArgs { Type = "blur" });
                break;
            case "OnChange":
                await element.ChangeAsync(new ChangeEventArgs { Value = "*" });
                break;
            case "OnInput":
                await element.InputAsync(new ChangeEventArgs { Value = "*" });
                break;
            case "OnDebounce":
                await element.InputAsync(new ChangeEventArgs { Value = "*" });
                break;
            case "ValueChanged":
                await element.ChangeAsync(new ChangeEventArgs { Value = "*" });
                break;
            case "ValueChanging":
                await element.InputAsync(new ChangeEventArgs { Value = "*" });
                break;
        }

        return eventInfo;
    }

    public class EventInfo
    {
        public EventInfo(string eventName)
            => Name = eventName;

        public bool IsEventFired { get; internal set; }

        public string Name { get; }
    }

    private static class EventHandlerFactory
    {
        private static readonly EventCallbackFactory EventCallbackFactory = new ();

        private static readonly object Receiver = new ();

        public static EventCallback CreateEventCallbackHandler(EventInfo eventInfo)
            => EventCallbackFactory.Create(Receiver, () => eventInfo.IsEventFired = true);

        public static EventCallback<T> CreateEventCallbackHandler1<T>(EventInfo eventInfo)
            => EventCallbackFactory.Create(Receiver, new Action<T>(_ => eventInfo.IsEventFired = true));

        public static Func<T, Task> CreateEventFuncHandler0<T>(EventInfo eventInfo)
            => _ => {
                eventInfo.IsEventFired = true;

                return Task.CompletedTask;
            };

        public static Func<T, ValueTask> CreateEventFuncHandler1<T>(EventInfo eventInfo)
            => _ => {
                eventInfo.IsEventFired = true;

                return default;
            };
    }
}