namespace RazorSharp.Components.Forms;

using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using RazorSharp.Core.Components.Rendering;
using RazorSharp.Dom;
using RazorSharp.Dom.Input;
using RazorSharp.Framework.Events;
using RazorSharp.JSInterop;
using RazorSharp.JSInterop.Wrappers;

public abstract class WebInputBase<TValue> : WebElementBase, IFormInput<TValue>
{
    private readonly EventHandler<ValidationStateChangedEventArgs> _onValidationStateChangedHandler;

    private bool _hasInitializedParameters;
    private bool _isGenericUnderlyingTypeNullable;
    private TValue? _originalValue;
    private bool _previousValidationAttemptFailed;
    private ValidationMessageStore? _validationMessages;

    protected WebInputBase(CultureInfo culture) : base(Tag.Input)
    {
        Culture = culture;

        _onValidationStateChangedHandler = OnValidationStateChangedHandler;
    }

    public CultureInfo Culture { get; }

    [Parameter]
    public int DebounceInterval { get; set; } = 250;

    [Parameter]
    public object? Form { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public EventCallback OnActivate { get; set; }

    [Parameter]
    public EventCallback OnBeforeActivate { get; set; }

    [Parameter]
    public EventCallback OnBeforeDeactivate { get; set; }

    [Parameter]
    public EventCallback OnBlur { get; set; }

    [Parameter]
    public EventCallback<ChangeEventArgs> OnChange { get; set; }

    [Parameter]
    public EventCallback OnDeactivate { get; set; }

    [Parameter]
    public Func<ChangeEventArgs, Task>? OnDebounce { get; set; }

    [Parameter]
    public EventCallback OnFocus { get; set; }

    [Parameter]
    public EventCallback OnFocusIn { get; set; }

    [Parameter]
    public EventCallback OnFocusOut { get; set; }

    [Parameter]
    public EventCallback<ChangeEventArgs> OnInput { get; set; }

    [Parameter]
    public EventCallback OnInvalid { get; set; }

    [Parameter]
    public string? Title { get; set; }

    public InputType Type { get; protected set; } = InputType.Default;

    [Parameter]
    public TValue? Value { get; set; }

    public string? ValueAsString
    {
        get
            => FormatValue(CurrentValue);
        protected set
            => SetParsedValue(value);
    }

    [Parameter]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public EventCallback<TValue> ValueChanged { get; set; }

    [Parameter]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public EventCallback<TValue> ValueChanging { get; set; }

    [Parameter]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    protected TValue? CurrentValue
    {
        get
            => Value;
        set
            => SetValue(value);
    }

    protected EditContext? EditContext { get; set; }

    protected FieldIdentifier FieldIdentifier { get; set; }

    protected virtual IHtmlElement? Input { get; private set; }

    protected virtual IDebounceable<ChangeEventArgs>? InputEventDebouncer { get; private set; }

    [CascadingParameter]
    private EditContext? CascadedEditContext { get; set; }

    public virtual async ValueTask BlurAsync()
    {
        if (Input is not null)
        {
            await Input.BlurAsync();
        }
    }

    public async ValueTask ClearAsync()
    {
        SetValue(default, false);

        await InvokeAsync(StateHasChanged);
    }

    public virtual async ValueTask FocusAsync(bool preventScroll = false)
    {
        if (Input is not null)
        {
            await Input.FocusAsync(preventScroll);
        }
    }

    public async ValueTask ResetAsync()
    {
        SetValue(_originalValue, false);

        await InvokeAsync(StateHasChanged);
    }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (_hasInitializedParameters is false)
        {
            if (CascadedEditContext is not null)
            {
                if (ValueExpression is null)
                {
                    throw new InvalidOperationException(
                        $"The type '{GetType()}' requires a value for the '{nameof(ValueExpression)}' parameter. Normally this is provided automatically when using 'bind-Value'.");
                }

                FieldIdentifier = FieldIdentifier.Create(ValueExpression);

                EditContext = CascadedEditContext;
                EditContext.OnValidationStateChanged -= _onValidationStateChangedHandler;
                EditContext.OnValidationStateChanged += _onValidationStateChangedHandler;
            }

            _isGenericUnderlyingTypeNullable = Nullable.GetUnderlyingType(typeof(TValue)) is not null;
            _hasInitializedParameters = true;
        }
        else if (CascadedEditContext != EditContext)
        {
            throw new InvalidOperationException(
                $"The type '{GetType()}' does not support changing the '{nameof(Microsoft.AspNetCore.Components.Forms.EditContext)}' parameter dynamically.");
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    protected override void BuildClass(CssClassBuilder builder)
    {
        base.BuildClass(builder);

        var fieldClass = EditContext?.FieldCssClass(FieldIdentifier);

        builder.Append(fieldClass);
    }

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        base.BuildElementRenderTree(builder);

        builder.AddAttribute(100, "type", Type);
        builder.AddAttribute(101, "value", ValueAsString);
        builder.AddAttributeIfNotNullOrEmpty(102, "name", Name);
        builder.AddAttribute(103, "form", Form);
        builder.AddAttributeIfNotNullOrEmpty(104, "title", Title);
        builder.AddAttribute(105, "disabled", IsDisabled);

        builder.AddEvent(106, "oninvalid", this, OnInvalidHandlerAsync);
        builder.AddEvent(107, "onactivate", this, OnActivateHandlerAsync);
        builder.AddEvent(108, "onbeforeactivate", this, OnBeforeActivateHandlerAsync);
        builder.AddEvent(109, "ondeactivate", this, OnDeactivateHandlerAsync);
        builder.AddEvent(110, "onbeforedeactivate", this, OnBeforeDeactivateHandlerAsync);

        builder.AddEvent<FocusEventArgs>(111, "onfocus", this, OnFocusHandlerAsync);
        builder.AddEvent<FocusEventArgs>(112, "onblur", this, OnFocusHandlerAsync);
        builder.AddEvent<FocusEventArgs>(113, "onfocusin", this, OnFocusHandlerAsync);
        builder.AddEvent<FocusEventArgs>(114, "onfocusout", this, OnFocusHandlerAsync);

        if (OnChange.HasDelegate)
        {
            builder.AddEvent<ChangeEventArgs>(115, "onchange", this, OnChangeHandlerAsync);
        }
        else if (ValueChanged.HasDelegate)
        {
            builder.AddBind(115,
                            "onchange",
                            this,
                            value => ValueAsString = value,
                            ValueAsString ?? "",
                            Culture);

            builder.SetUpdatesAttributeName("value");
        }

        if (OnInput.HasDelegate || OnDebounce is not null)
        {
            builder.AddEvent<ChangeEventArgs>(116, "oninput", this, OnInputHandlerAsync);
        }
        else if (ValueChanging.HasDelegate)
        {
            builder.AddBind(116,
                            "oninput",
                            this,
                            value => ValueAsString = value,
                            ValueAsString ?? "",
                            Culture);

            builder.SetUpdatesAttributeName("value");
        }
    }

    [SuppressMessage("ReSharper", "HeapView.PossibleBoxingAllocation")]
    protected virtual string FormatValue(TValue? value)
        => value?.ToString() ?? "";

    protected virtual async Task OnActivateHandlerAsync()
    {
        if (OnActivate.HasDelegate)
        {
            await OnActivate.InvokeAsync();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Input = await JSRuntime.CreateModuleAsyncAs<HtmlElement>(Ref);
            InputEventDebouncer = await EventDebouncerFactory.Create<ChangeEventArgs>(JSRuntime, Ref);
        }
    }

    protected virtual async Task OnBeforeActivateHandlerAsync()
    {
        if (OnBeforeActivate.HasDelegate)
        {
            await OnBeforeActivate.InvokeAsync();
        }
    }

    protected virtual async Task OnBeforeDeactivateHandlerAsync()
    {
        if (OnBeforeDeactivate.HasDelegate)
        {
            await OnBeforeDeactivate.InvokeAsync();
        }
    }

    protected virtual async Task OnChangeHandlerAsync(ChangeEventArgs args)
    {
        if (args.Value is null or string { Length: 0 })
        {
            return;
        }

        if (OnChange.HasDelegate)
        {
            await OnChange.InvokeAsync(args);
        }
    }

    protected virtual async Task OnDeactivateHandlerAsync()
    {
        if (OnDeactivate.HasDelegate)
        {
            await OnDeactivate.InvokeAsync();
        }
    }

    protected override void OnDispose()
    {
        base.OnDispose();

        if (EditContext is not null)
        {
            EditContext.OnValidationStateChanged -= _onValidationStateChangedHandler;
        }
    }

    protected override async ValueTask OnDisposeAsync()
    {
        await base.OnDisposeAsync();

        if (Input is not null)
        {
            await Input.DisposeAsync();
        }

        if (InputEventDebouncer is not null)
        {
            await ((IAsyncDisposable) InputEventDebouncer).DisposeAsync();
        }
    }

    protected virtual async Task OnFocusHandlerAsync(FocusEventArgs args)
    {
        switch (args.Type)
        {
            case "focus" when OnFocus.HasDelegate:
                await OnFocus.InvokeAsync();
                break;
            case "focusin" when OnFocusIn.HasDelegate:
                await OnFocusIn.InvokeAsync();
                break;
            case "focusout" when OnFocusOut.HasDelegate:
                await OnFocusOut.InvokeAsync();
                break;
            case "blur" when OnBlur.HasDelegate:
                await OnBlur.InvokeAsync();
                break;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _originalValue = Value;
    }

    protected virtual async Task OnInputHandlerAsync(ChangeEventArgs args)
    {
        if (args.Value is null or string { Length: 0 })
        {
            return;
        }

        if (OnDebounce is not null && InputEventDebouncer is not null)
        {
            await InputEventDebouncer.DebounceAsync(OnDebounce, args, DebounceInterval);

            await InvokeAsync(StateHasChanged);
        }
        else if (OnInput.HasDelegate)
        {
            await OnInput.InvokeAsync(args);
        }
    }

    protected virtual async Task OnInvalidHandlerAsync()
    {
        if (OnInvalid.HasDelegate)
        {
            await OnInvalid.InvokeAsync();
        }
    }

    protected virtual void OnValidationStateChanged()
    {
    }

    [SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
    protected virtual bool TryParseValue(string? value,
                                         [MaybeNullWhen(false)] out TValue result,
                                         [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = default!;
        validationErrorMessage = null;

        if (_isGenericUnderlyingTypeNullable && string.IsNullOrEmpty(value))
        {
            return true;
        }

        if (BindConverter.TryConvertTo(value, Culture, out result))
        {
            return true;
        }

        validationErrorMessage = $"The field '{FieldIdentifier.FieldName}' is invalid.";

        return false;
    }

    private void OnValidationStateChangedHandler(object? sender, ValidationStateChangedEventArgs args)
    {
        OnValidationStateChanged();

        StateHasChanged();
    }

    private void SetParsedValue(string? value)
    {
        if (IsDisabled)
        {
            return;
        }

        _validationMessages?.Clear();

        bool validationFailed;

        if (TryParseValue(value, out var parsedValue, out var validationErrorMessage))
        {
            validationFailed = false;

            CurrentValue = parsedValue;
        }
        else
        {
            validationFailed = true;

            if (EditContext is not null)
            {
                _validationMessages ??= new ValidationMessageStore(EditContext);
                _validationMessages.Add(FieldIdentifier, validationErrorMessage);

                EditContext.NotifyFieldChanged(FieldIdentifier);
            }
        }

        if (validationFailed || _previousValidationAttemptFailed)
        {
            EditContext?.NotifyValidationStateChanged();

            _previousValidationAttemptFailed = validationFailed;
        }
    }

    private void SetValue(TValue? value, bool shouldInvokeFieldChanged = true)
    {
        if (IsDisabled)
        {
            return;
        }

        var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, Value);

        if (hasChanged)
        {
            Value = value;

            if (ValueChanged.HasDelegate)
            {
                ValueChanged.InvokeAsync(Value);
            }

            if (ValueChanging.HasDelegate)
            {
                ValueChanging.InvokeAsync(Value);
            }

            if (shouldInvokeFieldChanged)
            {
                EditContext?.NotifyFieldChanged(FieldIdentifier);
            }
        }
    }
}