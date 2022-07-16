namespace AiCompanion.Memory;

internal static class MemoryLoader
{
    internal static MemoryBank LoadFromFile(string filepath)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("WARNING: MemoryLoader.LoadFromFile(string) Is not implemented! Currently it returns a new MemoryBank instead of loading old ones.");
        Console.ResetColor();
        return new MemoryBank();
    }
}