namespace Lib;

/// <summary>
/// Simple methods to work with string in app.
/// </summary>
public static class StringMethod
{
    /// <summary>
    /// Prepares string.
    /// Removes ending and opening whitespaces and double spaces.
    /// </summary>
    /// <param name="str">String.</param>
    /// <returns>Changed string.</returns>
    public static string RemoveExtraSpaces(string str)
    {
        while (str.Contains("  "))
        {
            str = str.Replace("  ", " ");
        }

        return str.Trim();
    }
    
    /// <summary>
    /// Makes first letter in specified string capitalized.
    /// </summary>
    /// <param name="word">Word to change.</param>
    /// <returns>New word with changed first letter.</returns>
    public static string Capitalize(string word)
    {
        if (word.Length == 0)
        {
            return word;
        }
        
        return word[..1].ToUpper() + word[1..].ToLower();
    }
}