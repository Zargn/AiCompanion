namespace AiCompanion.Memory;

[Serializable]
public class Memory
{
    public string Title;
    public List<string> ChildMemories = new();
    public List<string> IsMemories = new();
    public List<string> HasMemories = new();

    public Memory(string title)
    {
        Title = title;
    }
}