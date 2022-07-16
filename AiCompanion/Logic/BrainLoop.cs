using AiCompanion.Interfaces;

namespace AiCompanion.Logic;

internal class BrainLoop
{
    private Queue<IThought> thoughtQueue = new();

    private bool enabled = true;

    private EventWaitHandle thoughtQueueEmpty = new AutoResetEvent(false);

    private AiCompanion aiCompanion;
    
    public BrainLoop(AiCompanion aiCompanion)
    {
        this.aiCompanion = aiCompanion;
        new Thread(Loop).Start();
    }
    
    internal void AddThought(IThought thought)
    {
        thoughtQueue.Enqueue(thought);
        thoughtQueueEmpty.Set();
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