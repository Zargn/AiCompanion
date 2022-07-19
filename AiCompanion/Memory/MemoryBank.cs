namespace AiCompanion.Memory;

internal class MemoryBank
{
    internal Dictionary<string, Memory> Memories = new();

    internal IEnumerable<string> GetAllWords()
    {
        return Memories.Keys;
    }
}