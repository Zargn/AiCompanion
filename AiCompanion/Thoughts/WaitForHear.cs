using AiCompanion.Interfaces;

namespace AiCompanion.Thoughts;

internal class WaitForHear : ThoughtBaseConstructor, IThought
{
    public WaitForHear(AiCompanion aiCompanion, string wordToWaitFor) : base(aiCompanion)
    {
    }

    public void Think()
    {
        
    }
}