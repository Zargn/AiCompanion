using AiCompanion.Logic;
using AiCompanion.Memory;
using AiCompanion.Thoughts;

namespace AiCompanion;

public class AiCompanion
{
    public event Action<string>? CompanionOutput;
    public event Action<string>? CompanionLog;

    internal MemoryFragmentSystem MemoryFragmentSystem;
    internal BrainLoop brainLoop;

    internal int Patience => (Energy + Happiness) / 2;
    internal int Energy = 100;
    internal int Happiness = 100;
    
    public AiCompanion()
    {
        brainLoop = new BrainLoop(this);
        MemoryFragmentSystem = new MemoryFragmentSystem("MemoryTest", this);
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