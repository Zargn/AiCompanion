namespace AiCompanion.Memory;

internal class Memory
{
    internal string Title;
    internal List<Memory> ChildMemories;
    internal List<Memory> IsMemories;
    internal List<Memory> HasMemories;

    internal Memory(string title)
    {
        Title = title;
    }

    internal IEnumerable<Memory> GetAllChildMemories()
    {
        foreach (var memory in ChildMemories)
        {
            yield return memory;
            foreach (var childMemory in memory.GetAllChildMemories())
            {
                yield return childMemory;
            }
        }
    }
}