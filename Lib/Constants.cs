namespace Lib;

/// <summary>
/// Constant values (messages, error messages).
/// </summary>
internal struct Constants
{
    // Errors.
    public static readonly Func<List<char>, string> PathContainsInvalidChars = chs
        => $"The specified path contains invalid characters: {string.Join(", ", chs)}";
    public static readonly Func<string, string> PathContainsDirectorySeparator = path
        => $"The specified path: {path}, contains directory separator. Remove it, file must be saved near .exe file.";
}