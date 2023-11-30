namespace ControlHomework2_2;

/// <summary>
/// Constant values (messages).
/// </summary>
internal struct Constants
{
    // System messages.
    public const ConsoleKey ExitKeyboardKey = ConsoleKey.Q;
    public const string ProgramStartedMessage = "Program started.";
    public const string ProgramFinishedMessage = "Program finished.";
    public static readonly string AgainMessage = $"Press any key to restart or {ExitKeyboardKey} to exit.";
    public const string EnterFilePathMessage = "Enter path to the file.";
    public const string EnterCorrectFilePathMessage = "Enter correct file path.";
    
    // Error messages.
    public const string DefaultErrorMessage = "Something went wrong.";
    public static readonly Func<int, string> AttemptsLimitErrorMessage = limit 
        => $"You have reached the limit of attempts ({limit}) to enter the path, try again.";
    public static readonly Func<List<char>, string> PathContainsInvalidChars = chs
        => $"The specified path contains invalid characters: {string.Join(", ", chs)}";
}