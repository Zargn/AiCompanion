namespace AiCompanion;

public class AiCompanion
{
    public event Action<string> CompanionOutput;

    public bool CompanionInput(string s)
    {
        return false;
    }
}