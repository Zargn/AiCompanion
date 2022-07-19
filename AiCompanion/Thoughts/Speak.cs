using AiCompanion.Interfaces;

namespace AiCompanion.Thoughts;

internal class Speak : ThoughtBaseConstructor, IThought
{
    public Speak(AiCompanion aiCompanion, string message) : base(aiCompanion)
    {
        this.message = message;
    }

    private string message;
    
    public void Think()
    {
        aiCompanion.SendOutput(message);
    }
}