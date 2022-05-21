namespace RazorSharp.Components.Forms;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using AngleSharp.Diffing.Extensions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using RazorSharp.Dom.Input;
using RazorSharp.Tests.Kit;
using RazorSharp.Tests.Kit._Bunit;
using RazorSharp.Tests.TestDoubles.Fakes;
using RazorSharp.Tests.TestDoubles.Testables;

[SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.")]
[SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
public static class WebInputBaseTests
{
    [Fact]
    public static void Should_combine_existing_css_classes_with_field_class()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.AdditionalAttributes,
                           new Dictionary<string, object> { { "class", "my-class other-class" } });
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, webInput) = (hostComp.Instance,
                                hostComp.GetChildComponent().Instance);

        var oldCssClass = webInput.MergedClass;

        var fieldIdentifier = FieldIdentifier.Create(() => model.StringProperty);

        host.EditContext!.NotifyFieldChanged(fieldIdentifier);

        hostComp.Render();

        Assert.Multiple(() => Assert.Equal("my-class other-class valid", oldCssClass),
                        () => Assert.Equal("my-class other-class modified valid", webInput.MergedClass));
    }

    [Fact]
    public static void Should_expose_EditContext_to_subclass()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.Value, "foo");
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, webInput) = (hostComp.Instance,
                                hostComp.GetChildComponent().Instance);

        Assert.Same(host.EditContext, webInput.EditContext);
    }

    [Fact]
    public static void Should_expose_FieldIdentifier_to_subclass()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.Value, "foo");
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var fieldIdentifier = FieldIdentifier.Create(() => model.StringProperty);

        var webInput = hostComp.GetChildComponent().Instance;

        Assert.Equal(fieldIdentifier, webInput.FieldIdentifier);
    }

    [Fact]
    public static async Task Should_fire_OnActivate_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnActivate, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnBeforeActivate_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnBeforeActivate, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnBeforeDeactivate_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnBeforeDeactivate, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnBlur_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnBlur, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnChange_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnChange, "input", true);

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnDeactivate_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnDeactivate, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnDebounce_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnDebounce, "input", true);

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnFocus_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnFocus, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnFocusIn_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnFocusIn, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnFocusOut_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnFocusOut, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnInput_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnInput, "input", true);

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_OnInvalid_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.OnInvalid, "input");

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_ValueChanged_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.ValueChanged, "input", true);

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static async Task Should_fire_ValueChanged_event_when_the_value_was_changed()
    {
        using var ctx = new RazorSharpTestContext();

        var value = "foo";

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Bind(p => p.Value, value, newValue => value = newValue, () => value);
        });

        var (webInput, element) = (webInputComp.Instance,
                                   webInputComp.Find("input"));

        var wasValueChangedFiredAfterFirstRender = value != "foo";

        await element.ChangeAsync(new ChangeEventArgs { Value = "bar" });

        Assert.Multiple(() => Assert.False(wasValueChangedFiredAfterFirstRender),
                        () => Assert.Equal("bar", webInput.Value));
    }

    [Fact]
    public static async Task Should_fire_ValueChanged_event_when_the_value_was_parsed_successfully()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<DateTime, TestableDateInput>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueChanged, newValue => model.DateProperty = newValue);
            parameters.Add(p => p.ValueExpression, () => model.DateProperty);
        });

        var (host, element) = (hostComp.Instance,
                               hostComp.GetChildComponent().Find("input"));

        var fieldIdentifier = FieldIdentifier.Create(() => model.DateProperty);

        var validationStateChangesCounter = 0;

        host.EditContext!.OnValidationStateChanged += (_, _) => { validationStateChangesCounter++; };

        await element.ChangeAsync(new ChangeEventArgs { Value = "1991/11/20" });

        Assert.Multiple(() => Assert.Equal(1991, model.DateProperty.Year),
                        () => Assert.Equal(11, model.DateProperty.Month),
                        () => Assert.Equal(20, model.DateProperty.Day),
                        () => Assert.True(host.EditContext.IsModified(fieldIdentifier)),
                        () => Assert.Empty(host.EditContext.GetValidationMessages(fieldIdentifier)),
                        () => Assert.Equal(0, validationStateChangesCounter));
    }

    [Fact]
    [SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
    public static async Task Should_fire_ValueChanged_event_when_the_value_was_parsed_unsuccessfully()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<DateTime, TestableDateInput>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueChanged, newValue => model.DateProperty = newValue);
            parameters.Add(p => p.ValueExpression, () => model.DateProperty);
        });

        var (host, element) = (hostComp.Instance,
                               hostComp.GetChildComponent().Find("input"));

        var fieldIdentifier = FieldIdentifier.Create(() => model.DateProperty);

        var currentValidationStateChangesCounter = 0;

        host.EditContext!.OnValidationStateChanged += (_, _) => { currentValidationStateChangesCounter++; };

        await element.ChangeAsync(new ChangeEventArgs { Value = "1991/11/40" });

        var wasValueChanged = model.DateProperty != default;
        var wasFieldModified = host.EditContext.IsModified(fieldIdentifier);
        var oldValidationMessage = host.EditContext.GetValidationMessages(fieldIdentifier).Single();
        var oldValidationStateChangesCounter = currentValidationStateChangesCounter;

        await element.ChangeAsync(new ChangeEventArgs { Value = "1991/11/20" });

        Assert.Multiple(TransitionToInvalid()
                        .Concat(TransitionToValid())
                        .ToArray());

        IEnumerable<Action> TransitionToInvalid()
        {
            yield return () => Assert.False(wasValueChanged);
            yield return () => Assert.True(wasFieldModified);
            yield return () => Assert.Equal("Bad date value", oldValidationMessage);
            yield return () => Assert.Equal(1, oldValidationStateChangesCounter);
        }

        IEnumerable<Action> TransitionToValid()
        {
            yield return () => Assert.Equal(1991, model.DateProperty.Year);
            yield return () => Assert.Equal(11, model.DateProperty.Month);
            yield return () => Assert.Equal(20, model.DateProperty.Day);
            yield return () => Assert.True(host.EditContext.IsModified(fieldIdentifier));
            yield return () => Assert.Empty(host.EditContext.GetValidationMessages(fieldIdentifier));
            yield return () => Assert.Equal(2, currentValidationStateChangesCounter);
        }
    }

    [Fact]
    public static async Task Should_fire_ValueChanging_event()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo = await webInputComp.BindAndFireEvent(c => c.ValueChanging, "input", true);

        Assert.True(eventInfo.IsEventFired);
    }

    [Fact]
    public static void Should_format_the_value_according_to_supplied_formatting()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableDateInput>(parameters => {
            parameters.Add(p => p.Value, new DateTime(1915, 3, 2));
            parameters.Add(p => p.Format, "yyyy/MM/dd");
        });

        var webInput = webInputComp.Instance;

        Assert.Equal("1915/03/02", webInput.ValueAsString);
    }

    [Fact]
    public static void Should_match_css_class_to_the_corresponding_field_state()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, webInput) = (
            hostComp.Instance,
            hostComp.GetChildComponent().Instance);

        var fieldIdentifier = FieldIdentifier.Create(() => model.StringProperty);

        var initialCssClassValue = webInput.MergedClass;
        host.EditContext!.NotifyFieldChanged(fieldIdentifier);
        hostComp.Render();

        var modifiedCssClassValue = webInput.MergedClass;
        var messages = new ValidationMessageStore(host.EditContext);
        messages.Add(fieldIdentifier, "foo");
        hostComp.Render();

        var invalidCssClassValue = webInput.MergedClass;
        host.EditContext.MarkAsUnmodified(fieldIdentifier);
        hostComp.Render();

        var unmodifiedCssClassValue = webInput.MergedClass;
        messages.Clear();
        hostComp.Render();

        var validCssClassValue = webInput.MergedClass;

        Assert.Multiple(() => Assert.Equal("valid", initialCssClassValue),
                        () => Assert.Equal("modified valid", modifiedCssClassValue),
                        () => Assert.Equal("modified invalid", invalidCssClassValue),
                        () => Assert.Equal("invalid", unmodifiedCssClassValue),
                        () => Assert.Equal("valid", validCssClassValue));
    }

    [Fact]
    public static async Task Should_not_fire_ValueChanged_event_when_OnChange_is_set()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo1 = await webInputComp.BindAndFireEvent(c => c.OnChange, "input", true);
        var eventInfo2 = await webInputComp.BindAndFireEvent(c => c.ValueChanged, "input", true);

        Assert.Multiple(() => Assert.True(eventInfo1.IsEventFired),
                        () => Assert.False(eventInfo2.IsEventFired));
    }

    [Fact]
    [SuppressMessage("ReSharper", "ConvertToConstant.Local")]
    public static async Task Should_not_fire_ValueChanged_event_when_the_value_is_unchanged()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var value = "foo";
        var wasValueChangedFired = false;

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.Value, value);
            parameters.Add(p => p.ValueChanged, _ => wasValueChangedFired = true);
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var element = hostComp.GetChildComponent().Find("input");

        await element.ChangeAsync(new ChangeEventArgs { Value = "foo" });

        Assert.Multiple(() => Assert.False(wasValueChangedFired),
                        () => Assert.Equal("foo", value));
    }

    [Fact]
    public static async Task Should_not_fire_ValueChanging_event_when_OnInput_is_set()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var eventInfo1 = await webInputComp.BindAndFireEvent(c => c.OnInput, "input", true);
        var eventInfo2 = await webInputComp.BindAndFireEvent(c => c.ValueChanging, "input", true);

        Assert.Multiple(() => Assert.True(eventInfo1.IsEventFired),
                        () => Assert.False(eventInfo2.IsEventFired));
    }

    [Fact]
    public static void Should_not_render_with_disabled_when_Disabled_is_false()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.IsDisabled, false);
        });

        var element = webInputComp.Find("input");
        var disabled = element.HasAttribute("disabled");

        Assert.False(disabled);
    }

    [Fact]
    public static async Task Should_notify_EditContext_when_value_changed()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.Value, "foo");
            parameters.Add(p => p.ValueChanged, _ => { });
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, element) = (hostComp.Instance,
                               hostComp.GetChildComponent().Find("input"));

        var wasFieldModified = host.EditContext!.IsModified(() => model.StringProperty);

        await element.ChangeAsync(new ChangeEventArgs { Value = "bar" });

        Assert.Multiple(() => Assert.False(wasFieldModified),
                        () => Assert.True(host.EditContext!.IsModified(() => model.StringProperty)));
    }

    [Fact]
    public static void Should_render_with_disabled_when_Disabled_is_true()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.IsDisabled, true);
        });

        var element = webInputComp.Find("input");
        var disabled = element.HasAttribute("disabled");

        Assert.True(disabled);
    }

    [Fact]
    public static void Should_render_with_the_default_type_when_no_type_is_specified()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>();

        var webInput = webInputComp.Instance;

        Assert.Equal("text", ((IFormInput<string>) webInput).Type);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Form()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Form, "form1");
        });

        var element = webInputComp.Find("input");
        var form = element.GetAttribute("form");

        Assert.Equal("form1", form);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Name()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Name, "foo");
        });

        var element = webInputComp.Find("input");
        var name = element.GetAttribute("name");

        Assert.Equal("foo", name);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Title()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Title, "foo");
        });

        var element = webInputComp.Find("input");
        var title = element.GetAttribute("title");

        Assert.Equal("foo", title);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Value()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Value, "foo");
        });

        var element = webInputComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("foo", value);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Value_as_empty_when_null_is_passed()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Value, null);
        });

        var element = webInputComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("", value);
    }

    [Fact]
    [SuppressMessage("ReSharper",
                     "ConvertToConstant.Local",
                     Justification = "FieldIdentifier does not support ConstantExpression")]
    public static void Should_render_without_EditContext()
    {
        using var ctx = new RazorSharpTestContext();

        var value = "foo";

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Value, value);
            parameters.Add(p => p.ValueExpression, () => value);
        });

        var webInput = hostComp.GetChildComponent().Instance;

        Assert.Null(webInput.EditContext);
    }

    [Fact]
    [SuppressMessage("ReSharper", "InlineTemporaryVariable")]
    public static async Task Should_respond_to_changes()
    {
        using var ctx = new RazorSharpTestContext();

        var value = "foo";

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.Value, value);
            parameters.Add(p => p.ValueChanged, newValue => value = newValue);
            parameters.Add(p => p.ValueExpression, () => value);
        });

        var oldValue = value;

        var element = hostComp.GetChildComponent().Find("input");

        await element.ChangeAsync(new ChangeEventArgs { Value = "bar" });

        Assert.Multiple(() => Assert.Equal("foo", oldValue),
                        () => Assert.Equal("bar", value));
    }

    [Fact]
    public static async Task Should_respond_to_validation_state_change_notifications()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, webInput) = (hostComp.Instance,
                                hostComp.GetChildComponent().Instance);

        var fieldIdentifier = FieldIdentifier.Create(() => model.StringProperty);

        var messageStore = new ValidationMessageStore(host.EditContext!);
        messageStore.Add(fieldIdentifier, "foo");
        await hostComp.InvokeAsync(host.EditContext!.NotifyValidationStateChanged);

        Assert.Equal(1, webInput.ValidationStateChangedCounter);
    }

    [Fact]
    public static void Should_throw_when_EditContext_changes()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var ex = Record.Exception(() => {
            hostComp.Instance.EditContext = new (model);
            hostComp.Render();
        });

        Assert.Multiple(() => Assert.NotNull(ex),
                        () => Assert.StartsWith(
                            $"The type '{typeof(TestableWebInput<string>)}' does not support changing the 'EditContext' parameter dynamically.",
                            ex?.Message));
    }

    [Fact]
    public static void Should_throw_when_no_ValueExpression_is_supplied()
    {
        var ex = Record.Exception(() => {
            using var ctx = new RazorSharpTestContext();

            var model = new FakeModel();

            ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
                parameters.Add(p => p.EditContext, new (model));
            });
        });

        Assert.Multiple(() => Assert.NotNull(ex),
                        () => Assert.StartsWith(
                            $"The type '{typeof(TestableWebInput<string>)}' requires a value for the 'ValueExpression' parameter. Normally this is provided automatically when using 'bind-Value'.",
                            ex?.Message));
    }

    [Fact]
    public static async Task Should_unsubscribe_from_validation_state_change_notifications()
    {
        using var ctx = new RazorSharpTestContext();

        var model = new FakeModel();

        var hostComp = ctx.RenderHostComponent<string, TestableWebInput<string>>(parameters => {
            parameters.Add(p => p.EditContext, new (model));
            parameters.Add(p => p.ValueExpression, () => model.StringProperty);
        });

        var (host, webInput) = (hostComp.Instance,
                                hostComp.GetChildComponent().Instance);

        var fieldIdentifier = FieldIdentifier.Create(() => model.StringProperty);

        await webInput.DisposeAsync();

        var messageStore = new ValidationMessageStore(host.EditContext!);
        messageStore.Add(fieldIdentifier, "foo");
        await hostComp.InvokeAsync(host.EditContext!.NotifyValidationStateChanged);

        Assert.Equal(0, webInput.ValidationStateChangedCounter);
    }

    public static class ClearAsync
    {
        [Fact]
        public static async Task Should_clear_input_element()
        {
            using var ctx = new RazorSharpTestContext();

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Add(p => p.Value, "foo");
            });

            var (webInput, element) = (webInputComp.Instance,
                                       webInputComp.Find("input"));

            element.TryGetAttrValue("value", out string oldValue);

            await webInput.ClearAsync();

            element.TryGetAttrValue("value", out string newValue);

            Assert.Multiple(() => Assert.Equal("foo", oldValue),
                            () => Assert.Equal("", newValue));
        }

        [Fact]
        public static async Task Should_rerender_component_when_Value_is_binded_and_cleared()
        {
            using var ctx = new RazorSharpTestContext();

            var currentValue = "foo";

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Bind(p => p.Value, currentValue, newValue => currentValue = newValue);
            });

            var webInput = webInputComp.Instance;

            await webInput.ClearAsync();

            Assert.Equal(2, webInputComp.RenderCount);
        }

        [Fact]
        public static async Task Should_set_Value_to_default()
        {
            using var ctx = new RazorSharpTestContext();

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Add(p => p.Value, "foo");
            });

            var webInput = webInputComp.Instance;

            await webInput.ClearAsync();

            Assert.Equal(default, webInput.Value);
        }
    }

    public static class ResetAsync
    {
        [Fact]
        public static async Task Should_rerender_component_when_Value_is_binded_and_reset()
        {
            using var ctx = new RazorSharpTestContext();

            var currentValue = "foo";

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Bind(p => p.Value, currentValue, newValue => currentValue = newValue);
            });

            var webInput = webInputComp.Instance;

            await webInput.ResetAsync();

            Assert.Equal(2, webInputComp.RenderCount);
        }

        [Fact]
        public static async Task Should_reset_input_element_to_original_value()
        {
            using var ctx = new RazorSharpTestContext();

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Add(p => p.Value, "foo");
            });

            var (webInput, element) = (webInputComp.Instance,
                                       webInputComp.Find("input"));

            webInputComp.SetParametersAndRender(parameters => { parameters.Add(p => p.Value, "bar"); });

            element.TryGetAttrValue("value", out string newValue);

            await webInput.ResetAsync();

            element.TryGetAttrValue("value", out string oldValue);

            Assert.Multiple(() => Assert.Equal("foo", oldValue),
                            () => Assert.Equal("bar", newValue));
        }

        [Fact]
        public static async Task Should_reset_Value_to_original_value()
        {
            using var ctx = new RazorSharpTestContext();

            var webInputComp = ctx.RenderComponent<TestableWebInput<string>>(parameters => {
                parameters.Add(p => p.Value, "foo");
            });

            var webInput = webInputComp.Instance;

            webInputComp.SetParametersAndRender(parameters => {
                parameters.Add(p => p.Value, "bar");
            });

            var newValue = webInput.Value;

            await webInput.ResetAsync();

            var oldValue = webInput.Value;

            Assert.Multiple(() => Assert.Equal("bar", newValue),
                            () => Assert.Equal("foo", oldValue));
        }
    }
}