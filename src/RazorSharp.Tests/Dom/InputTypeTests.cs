namespace RazorSharp.Dom;

using RazorSharp.Dom.Input;

public static class InputTypeTests
{
    [Fact]
    public static void Should_return_checkbox()
    {
        Assert.Equal("checkbox", InputType.CheckBox);
    }

    [Fact]
    public static void Should_return_color()
    {
        Assert.Equal("color", InputType.Color);
    }

    [Fact]
    public static void Should_return_date()
    {
        Assert.Equal("date", InputType.Date);
    }

    [Fact]
    public static void Should_return_datetime_local()
    {
        Assert.Equal("datetime-local", InputType.DateTime);
    }

    [Fact]
    public static void Should_return_email()
    {
        Assert.Equal("email", InputType.Email);
    }

    [Fact]
    public static void Should_return_file()
    {
        Assert.Equal("file", InputType.File);
    }

    [Fact]
    public static void Should_return_image()
    {
        Assert.Equal("image", InputType.Image);
    }

    [Fact]
    public static void Should_return_month()
    {
        Assert.Equal("month", InputType.Month);
    }

    [Fact]
    public static void Should_return_number()
    {
        Assert.Equal("number", InputType.Number);
    }

    [Fact]
    public static void Should_return_password()
    {
        Assert.Equal("password", InputType.Password);
    }

    [Fact]
    public static void Should_return_radio()
    {
        Assert.Equal("radio", InputType.Radio);
    }

    [Fact]
    public static void Should_return_range()
    {
        Assert.Equal("range", InputType.Range);
    }

    [Fact]
    public static void Should_return_search()
    {
        Assert.Equal("search", InputType.Search);
    }

    [Fact]
    public static void Should_return_submit()
    {
        Assert.Equal("submit", InputType.Submit);
    }

    [Fact]
    public static void Should_return_tel()
    {
        Assert.Equal("tel", InputType.Telephone);
    }

    [Fact]
    public static void Should_return_text()
    {
        Assert.Equal("text", InputType.Text);
    }

    [Fact]
    public static void Should_return_time()
    {
        Assert.Equal("time", InputType.Time);
    }

    [Fact]
    public static void Should_return_url()
    {
        Assert.Equal("url", InputType.Url);
    }

    [Fact]
    public static void Should_return_week()
    {
        Assert.Equal("week", InputType.Week);
    }
}