using AiCompanion.Interfaces;
using AiCompanion.Memory;

namespace AiCompanion.Logic;

internal class BrainLoop
{
    private readonly Queue<IThought> thoughtQueue = new();
    private readonly EventWaitHandle thoughtQueueEmpty = new AutoResetEvent(false);
    private readonly AiCompanion aiCompanion;
    
    private bool enabled = true;

    internal ShortTermMemory ShortTermMemory;
    internal event Action? ThoughtAdded;

    public BrainLoop(AiCompanion aiCompanion)
    {
        this.aiCompanion = aiCompanion;
        new Thread(Loop).Start();
    }
    
    internal void AddThought(IThought thought)
    {
        thoughtQueue.Enqueue(thought);
        thoughtQueueEmpty.Set();
        ThoughtAdded?.Invoke();
    }

    internal void AddThoughts(IEnumerable<IThought> thoughts)
    {
        foreach (var thought in thoughts)
        {
            AddThought(thought);
        }
    }

    private void Loop()
    {
        while (enabled)
        {
            if (thoughtQueue.Count == 0)
                Idle();
            else
                thoughtQueue.Dequeue().Think();
        }
    }

    private void Idle()
    {
        aiCompanion.SendLog("Pause brain loop.");
        thoughtQueueEmpty.WaitOne();
        aiCompanion.SendLog("Resume brain loop.");
    }
}