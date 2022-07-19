using AiCompanion.Interfaces;

namespace AiCompanion.Thoughts;

internal class Hear : ThoughtBaseConstructor, IThought
{
    public Hear(AiCompanion aiCompanion, string message) : base(aiCompanion)
    {
        aiCompanion.SendLog($"Created hear thought for: [{message}]");
        this.message = message;
    }

    private string message;

    public void Think()
    {
        aiCompanion.SendLog($"Companion heard [{message}]");
        var thoughts = new List<IThought>();
        foreach (var word in ExtractWords(message))
        {
            thoughts.Add(new AnalyzeWord(aiCompanion, word));
        }
        aiCompanion.brainLoop.AddThoughts(thoughts);
    }

    private IEnumerable<string> ExtractWords(string sentence)
    {
        int nextWordStartPosition = 0;
        int index;
        for (index = 0; index < sentence.Length; index++)
        {
            if (sentence[index] is ' ' or '.' or ',')
            {
                yield return sentence.Substring(nextWordStartPosition, index - nextWordStartPosition);
                nextWordStartPosition = index + 1;
            }
        }
        
        yield return sentence.Substring(nextWordStartPosition, index - nextWordStartPosition);
    }
}