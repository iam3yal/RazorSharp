namespace RazorSharp.Dom.Input;

public interface IFileInput : IFormInput<string>
{
    /// <summary>
    ///     Determines which file types are selectable in a file upload control.
    /// </summary>
    string? Accept { get; set; }

    /// <summary>
    ///     Determines which media—microphone, video, or camera—should be used to capture a new file for upload with file upload control in supporting scenarios.
    /// </summary>
    string? Capture { get; set; }

    /// <summary>
    ///     Determines whether it's possible to choose more than one file.
    /// </summary>
    bool Multiple { get; set; }
}