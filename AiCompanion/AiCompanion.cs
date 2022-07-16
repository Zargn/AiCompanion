namespace AiCompanion;

public class AiCompanion
{
    public event Action<string> CompanionOutput;

    public bool CompanionInput(string s)
    {
        if (StringIsAllowed(s))
        {
            // Do something
            return true;
        }

        return false;
    }

    private bool StringIsAllowed(string s)
    {
        return true;
    }
}