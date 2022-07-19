using AiCompanion.Logic;
using AiCompanion.Memory;
using AiCompanion.Thoughts;

namespace AiCompanion;

public class AiCompanion
{
    public event Action<string>? CompanionOutput;
    public event Action<string>? CompanionLog;

    internal MemoryBank memoryBank;
    internal BrainLoop brainLoop;
    
    public AiCompanion()
    {
        memoryBank = MemoryLoader.LoadFromFile("Add filepath here when functionality is completed.");
        brainLoop = new BrainLoop(this);
    }
    
    public bool CompanionInput(string inputString)
    {
        if (StringIsAllowed(inputString))
        {
            SendLog("User input passed checks.");
            
            brainLoop.AddThought(new Hear(this, inputString));
            
            return true;
        }

        return false;
    }

    private bool StringIsAllowed(string s)
    {
        return true;
    }

    internal void SendLog(string s)
    {
        CompanionLog?.Invoke(s);
    }

    internal void SendOutput(string s)
    {
        CompanionOutput?.Invoke(s);
    }
}