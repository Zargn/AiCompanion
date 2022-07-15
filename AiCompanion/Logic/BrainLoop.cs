using AiCompanion.Interfaces;

namespace AiCompanion.Logic;

internal class BrainLoop
{
    private Queue<IThought> thoughtQueue = new();

    internal bool Enabled;

    internal void AddThought(IThought thought)
    {
        
    }

    private void Loop()
    {
        while (Enabled)
        {
            if (thoughtQueue.Count == 0)
                Idle();
            else
                thoughtQueue.Dequeue().Think();
        }
    }

    private void Idle()
    {
        
    }
}