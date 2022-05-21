namespace RazorSharp.Tests.Kit;

using System.Linq.Expressions;

using Bunit;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Components;

public sealed class RazorSharpTestContext : IDisposable
{
    private readonly TestContext _ctx;

    public RazorSharpTestContext()
    {
        _ctx = new TestContext();
        _ctx.JSInterop.Mode = JSRuntimeMode.Loose;
    }

    public void Dispose()
    {
        _ctx.DisposeComponents();
        _ctx.Dispose();
    }

    public IRenderedComponent<TComponent> RenderComponent<TComponent>(
        Action<ComponentParameterCollectionBuilder<TComponent>>? parameters = null)
        where TComponent : IComponent
        => _ctx.RenderComponent(parameters);

    public IRenderedComponent<FakeHostComponent<TValue, TComponent>> RenderHostComponent<TValue, TComponent>(
        Action<ComponentParameterCollectionBuilder<FakeHostComponent<TValue, TComponent>>>? parameters = null)
        where TComponent : IComponent
        => _ctx.RenderComponent(parameters);

    // NOTE: This is similar to TestInputHostComponent with slight modifications to make it work with bUnit.
    // REF: https://github.com/dotnet/aspnetcore/blob/v7.0.9/src/Components/Web/test/Forms/TestInputHostComponent.cs
    public sealed class FakeHostComponent<TValue, TComponent> : WebComponent
        where TComponent : IComponent
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public EditContext? EditContext { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public Action<TValue>? ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TValue>>? ValueExpression { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<EditContext>>(0);
            builder.AddAttribute(1, "Value", EditContext);
            builder.AddAttribute(2,
                                 "ChildContent",
                                 new RenderFragment(childBuilder => {
                                     childBuilder.OpenComponent<TComponent>(0);
                                     childBuilder.AddAttribute(1, "Value", Value);

                                     if (ValueChanged is not null)
                                     {
                                         childBuilder.AddAttribute(2,
                                                                   "ValueChanged",
                                                                   EventCallback.Factory.Create(this, ValueChanged));
                                     }

                                     childBuilder.AddAttribute(3, "ValueExpression", ValueExpression);
                                     childBuilder.AddMultipleAttributes(4, AdditionalAttributes);
                                     childBuilder.CloseComponent();
                                 }));
            builder.CloseComponent();
        }
    }
}