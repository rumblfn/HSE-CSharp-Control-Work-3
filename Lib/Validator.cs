namespace Lib;

/// <summary>
/// Validates strings for specified conditions.
/// </summary>
public static class Validator
{
    // Necessary vowels for tracking.
    private static readonly char[] Vowels =
    {
        'a', 'e', 'i', 'o', 'u', 'y',
        'A', 'E', 'I', 'O', 'U', 'Y',
        'а', 'я', 'у', 'ю', 'о', 'е', 'ё', 'э', 'и', 'ы',
        'А', 'Я', 'У', 'Ю', 'О', 'Е', 'Ё', 'Э', 'И', 'Ы',
    };
    
    private static readonly char[] AcceptableLetters =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 
        'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 
        'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', ' ',
        'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
    };

    /// <summary>
    /// Check if all letters in specified string contains
    /// only acceptable letters <see cref="AcceptableLetters"/>.
    /// </summary>
    /// <param name="str">String to check.</param>
    /// <returns>Is valid.</returns>
    public static bool IsValid(string str)
    {
        return str.All(ch => AcceptableLetters.Contains(ch));
    }
    
    /// <summary>
    /// Checks if letter is vowel.
    /// </summary>
    /// <param name="ch">Letter to check.</param>
    /// <returns>Is vowel.</returns>
    public static bool IsVowel(char ch)
    {
        return Vowels.Contains(ch);
    }
    
    /// <summary>
    /// Validates output path.
    /// The generated file must be saved near .exe file.
    /// </summary>
    /// <param name="path">Output path.</param>
    /// <exception cref="ArgumentException">Incorrect path.</exception>
    public static void ValidateOutputPath(string path)
    {
        List<char> incorrectChars = Path.GetInvalidPathChars().Where(path.Contains).ToList();

        if (incorrectChars.Count > 0)
        {
            throw new ArgumentException(Constants.PathContainsInvalidChars(incorrectChars));
        }

        if (path.Contains(Path.DirectorySeparatorChar))
        {
            throw new ArgumentException(Constants.PathContainsDirectorySeparator(path));
        }
    }
}