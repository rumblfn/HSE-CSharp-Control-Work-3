namespace Lib;

/// <summary>
/// Contains methods to parse input data.
/// </summary>
public static class DataParses
{
    /// <summary>
    /// Finds correct sentences in specified line.
    /// Correct sentence contains only valid letters (ru or eng) and has point at the end.
    /// </summary>
    /// <param name="line">Line from file.</param>
    /// <returns>Array of correct sentences.</returns>
    private static List<string> ParseSentencesInLine(string line)
    {
        List<string> parsedSentencesInLine = new ();
        string[] sentencesInLine = line.Split('.');
        for (int i = 0; i < sentencesInLine.Length - 1; i++)
        {
            string current = StringMethod.RemoveExtraSpaces(sentencesInLine[i]);
            if (Validator.IsValid(current) && current.Length > 0)
            {
                parsedSentencesInLine.Add(current);
            }
            else
            {
                ConsoleMethod.NicePrint($"Incorrect sentence: {current}", CustomColor.ErrorColor);
            }
        }

        return parsedSentencesInLine;
    }

    /// <summary>
    /// Converts each line to array of abbreviations of correct sentences.
    /// </summary>
    /// <param name="lines">Array of lines from file.</param>
    /// <returns>
    /// Array of line that contains one or more correct sentence and array
    /// of <see cref="MyStrings"/> where array indexes correspond to sentences.
    /// </returns>
    public static (List<string>, MyStrings[]) ParseLines(string[] lines)
    {
        List<string> linesWithOneOrMoreCorrectSentences = new();
        List<MyStrings> linesWithSentences = new ();
        
        foreach (string line in lines)
        {
            if (!line.Contains('.'))
            {
                continue;
            }

            List<string> sentences = ParseSentencesInLine(line);

            if (sentences.Count == 0)
            {
                continue;
            }

            linesWithOneOrMoreCorrectSentences.Add(line);
            linesWithSentences.Add(new MyStrings(string.Join('.', sentences), '.'));
        }

        return (linesWithOneOrMoreCorrectSentences, linesWithSentences.ToArray());
    }
}