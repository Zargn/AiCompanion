namespace LocalUi;
using AiCompanion;

public static class LocalUi
{
    public static void Main()
    {
        var aiCompanion = new AiCompanion();

        ConfigureOutput(aiCompanion);
        
        RunUiLoop(aiCompanion);
        
        Console.WriteLine("Done");
    }

    private static void ConfigureOutput(AiCompanion aiCompanion)
    {
        aiCompanion.CompanionOutput += Console.WriteLine;
    }

    private static void RunUiLoop(AiCompanion aiCompanion)
    {
        while (true)
        {
            var userInput = Console.ReadLine();
            if (userInput == null)
                return;
            aiCompanion.CompanionInput(userInput);
        }
    }
}