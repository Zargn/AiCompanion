namespace AiCompanion.Thoughts;

internal abstract class ThoughtBaseConstructor
{
    protected AiCompanion aiCompanion;
    
    internal ThoughtBaseConstructor(AiCompanion aiCompanion)
    {
        this.aiCompanion = aiCompanion;
    }
}