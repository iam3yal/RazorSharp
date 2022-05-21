namespace RazorSharp.Dom.Input;

using RazorSharp.Core;
using RazorSharp.Core.Strings;

public sealed record InputType : TypedString<InputType>, IValueDefaultable<InputType>
{
    private InputType(string value) : base(value)
    {
    }

    public static InputType CheckBox { get; } = new ("checkbox");

    public static InputType Color { get; } = new ("color");

    public static InputType Date { get; } = new ("date");

    public static InputType DateTime { get; } = new ("datetime-local");

    public static InputType Default
        => Text;

    public static InputType Email { get; } = new ("email");

    public static InputType File { get; } = new ("file");

    public static InputType Image { get; } = new ("image");

    public static InputType Month { get; } = new ("month");

    public static InputType Number { get; } = new ("number");

    public static InputType Password { get; } = new ("password");

    public static InputType Radio { get; } = new ("radio");

    public static InputType Range { get; } = new ("range");

    public static InputType Search { get; } = new ("search");

    public static InputType Submit { get; } = new ("submit");

    public static InputType Telephone { get; } = new ("tel");

    public static InputType Text { get; } = new ("text");

    public static InputType Time { get; } = new ("time");

    public static InputType Url { get; } = new ("url");

    public static InputType Week { get; } = new ("week");
}