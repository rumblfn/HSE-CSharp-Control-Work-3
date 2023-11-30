using System.Text;
using Lib;

namespace ControlHomework2_2;

/// <summary>
/// Main class of the program.
/// </summary>
internal static class Program
{
    private const int AttemptsLimit = 100;
    
    /// <summary>
    /// Checks for exit from the program.
    /// </summary>
    /// <returns>Key is not <see cref="Constants.ExitKeyboardKey"/>.</returns>
    private static bool HandleAgain()
    {
        ConsoleMethod.NicePrint(Constants.AgainMessage, CustomColor.SystemColor);
        return ConsoleMethod.ReadKey() != Constants.ExitKeyboardKey;
    }

    /// <summary>
    /// Saves data to file with specified path.
    /// The maximum number of attempts <see cref="AttemptsLimit"/>,
    /// this is necessary so that there is no error of the recursive call limit.
    /// </summary>
    /// <param name="data">Data to save.</param>
    /// <param name="attemptNumber">Number of save attempt.</param>
    private static void SaveDataToFile(string data, int attemptNumber = 1)
    {
        try
        {
            ConsoleMethod.NicePrint("Enter path to save.");
            
            string savePath = ConsoleMethod.ReadLine();
            Validator.ValidateOutputPath(savePath);
            
            File.WriteAllText(savePath, data);
            ConsoleMethod.NicePrint("Data saved.");
        }
        catch (Exception ex)
        {
            if (attemptNumber == AttemptsLimit)
            {
                ConsoleMethod.NicePrint(Constants.AttemptsLimitErrorMessage(AttemptsLimit), CustomColor.ErrorColor);
                return;
            }
            
            ConsoleMethod.NicePrint(ex.Message, CustomColor.ErrorColor);
            ConsoleMethod.NicePrint(Constants.EnterCorrectFilePathMessage, CustomColor.ErrorColor);
            SaveDataToFile(data, attemptNumber + 1);
        }
    }

    /// <summary>
    /// A full cycle of actions.
    /// </summary>
    private static void Run()
    {
        ConsoleMethod.NicePrint(Constants.EnterFilePathMessage);
        string path = ConsoleMethod.ReadLine();
        string[] lines = File.ReadAllLines(path);

        (List<string> linesWithSentences, MyStrings[] mss) = DataParses.ParseLines(lines);

        StringBuilder data = new ();
        for (int i = 0; i < linesWithSentences.Count; i++)
        {
            data.Append(linesWithSentences[i] + Environment.NewLine);
            data.Append(string.Join(":", mss[i].ABBR) + Environment.NewLine);
        }

        SaveDataToFile(data.ToString());
    }
    
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    private static void Main()
    {
        ConsoleMethod.NicePrint(Constants.ProgramStartedMessage, CustomColor.SystemColor);
        
        do
        {           
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                ConsoleMethod.NicePrint(Constants.DefaultErrorMessage, CustomColor.ErrorColor);
                ConsoleMethod.NicePrint(ex.Message, CustomColor.ErrorColor);
            }
        } while (HandleAgain());
        
        ConsoleMethod.NicePrint(Constants.ProgramFinishedMessage, CustomColor.ProgressColor);
    }
}
