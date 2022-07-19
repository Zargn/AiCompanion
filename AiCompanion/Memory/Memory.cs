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

    internal List<Memory> GetAllChildMemories()
    {
        var result = new List<Memory>();
        foreach (var memory in ChildMemories)
        {
            result.AddRange(memory.ChildMemories);
        }
    }
}