using System.Text;

namespace Lib;

/// <summary>
/// The main class for working with data.
/// </summary>
public class MyStrings
{
    private readonly string[] _sentences = Array.Empty<string>();
    private string[] Sentences
    {
        get => _sentences;
        init => _sentences = value.Select(sentence => sentence.Trim()).ToArray();
    }
    public string[] ABBR => Abbreviation.GetSentencesAsAbbreviations(Sentences);

    /// <summary>
    /// Initializing an instance of the class.
    /// </summary>
    /// <param name="str">Line with sentences.</param>
    /// <param name="ch">Sentences separator.</param>
    public MyStrings(string str, char ch)
    {
        Sentences = str.Split(ch);
    }
}