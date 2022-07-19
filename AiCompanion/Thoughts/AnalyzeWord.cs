using AiCompanion.Interfaces;

namespace AiCompanion.Thoughts;

internal class AnalyzeWord : ThoughtBaseConstructor, IThought
{
    public AnalyzeWord(AiCompanion aiCompanion, string word) : base(aiCompanion)
    {
        this.word = word;
    }

    private string word;

    public void Think()
    {
        aiCompanion.SendLog($"Analyzing word: [{word}]");
        
        if (aiCompanion.memoryBank.Memories.ContainsKey(word))
        {
            aiCompanion.brainLoop.ShortTermMemory.MemoryReferences.Add(aiCompanion.memoryBank.Memories[word]);
        }
        else
        {
            if (TryFindSimilarWords(out var foundWord))
            {
                aiCompanion.brainLoop.ShortTermMemory.MemoryReferences.Add(aiCompanion.memoryBank.Memories[foundWord]);
            }
            else
            {
                aiCompanion.brainLoop.AddThought(new Speak(aiCompanion, $"I do not know what [{word}] means. Can you explain?"));
            }
        }
        // Check if the word is known.
        // If it is then add the memory of that word to the short term memory
        // If it is not then try to figure out what it means.
    }

    private bool TryFindSimilarWords(out string foundWord)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("WARNING: AnalyzeWord.TryFindSimilarWords(out string foundWord) Is not implemented! Currently always returns false.");
        Console.ResetColor();
        foundWord = null;
        return false;
    }
}