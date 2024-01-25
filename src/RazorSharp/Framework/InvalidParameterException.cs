namespace RazorSharp.Framework;

public sealed class InvalidParameterException(string parameterName, string? message) : Exception(
    string.IsNullOrEmpty(message)
        ? $"The parameter '{parameterName}' is invalid."
        : $"The parameter '{parameterName}' is invalid. {message}");