using AiCompanion.Interfaces;

namespace AiCompanion.Thoughts;

internal class Hear : ThoughtBaseConstructor, IThought
{
    public Hear(AiCompanion aiCompanion, string message) : base(aiCompanion)
    {
        aiCompanion.SendLog($"Created hear thought for: [{message}]");
        this.message = message;
    }

    private string message;

    public void Think()
    {
        aiCompanion.SendLog($"Companion heard [{message}]");
    }
}