using System.Text;

namespace Lib;

/// <summary>
/// Work with abbreviations.
/// </summary>
public static class Abbreviation
{
    /// <summary>
    /// Converts a sentence into an abbreviation.
    /// Rule: the first letter of a word becomes a capital letter,
    /// the word is read before the first vowel from the Russian or English alphabets,
    /// spaces between words are removed.
    /// </summary>
    /// <param name="sentence">Sentence to transform.</param>
    /// <returns>Abbreviation of sentence by specified rules.</returns>
    private static string GetSentenceAbbreviation(string sentence)
    {
        StringBuilder currentAbbr = new ();
        foreach (string word in sentence.Split(' '))
        {
            string capitalizedWord = StringMethod.Capitalize(word);
            foreach (char letter in capitalizedWord)
            {
                currentAbbr.Append(letter);
                if (Validator.IsVowel(letter))
                {
                    break;
                }
            }
        }

        return currentAbbr.ToString();
    }

    /// <summary>
    /// Translates sentences to it's abbreviations,
    /// using method <see cref="GetSentenceAbbreviation"/>
    /// </summary>
    /// <returns>Array of abbreviations.</returns>
    public static string[] GetSentencesAsAbbreviations(string[] sentences)
    {
        string[] result = new string[sentences.Length];
        for (int i = 0; i < sentences.Length; i++)
        {
            result[i] = GetSentenceAbbreviation(sentences[i]);
        }

        return result;
    }
}