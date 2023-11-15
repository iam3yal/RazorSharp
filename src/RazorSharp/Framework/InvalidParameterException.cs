namespace RazorSharp.Framework;

public sealed class InvalidParameterException : Exception
{
    public InvalidParameterException(string parameterName, string? message)
        : base(string.IsNullOrEmpty(message)
                   ? $"The parameter '{parameterName}' is invalid."
                   : $"The parameter '{parameterName}' is invalid. {message}")
    {
    }
}