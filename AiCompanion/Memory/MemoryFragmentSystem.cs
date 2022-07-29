using System.Text.Json;
using AiCompanion.Interfaces;

namespace AiCompanion.Memory;

internal class MemoryFragmentSystem
{
    private const string basePath = "AiMemories/";
    private readonly JsonSerializerOptions serializeAllFields = new() {IncludeFields = true};
    
    private string entityName;
    private readonly string instancePath;

    private MemoryBank memoryBank = new();
    private AiCompanion aiCompanion;

    internal MemoryFragmentSystem(string entityName, AiCompanion aiCompanion)
    {
        this.entityName = entityName;
        this.aiCompanion = aiCompanion;
        instancePath = basePath + entityName + "/";
        PopulateMemoryBankFromFiles();
    }
    
    internal void SaveMemoryFragment(Memory memory)
    {
        var path = instancePath + memory.Title + ".json";
        string json = JsonSerializer.Serialize(memory, serializeAllFields);
        File.WriteAllText(path, json);
    }

    internal Memory GetMemoryByTitle(string memoryTitle)
    {
        var pathToFile = instancePath + memoryTitle + ".json";
        try
        {
            string json = File.ReadAllText(pathToFile);
            return JsonSerializer.Deserialize<Memory>(json, serializeAllFields)!;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
            throw new Exception("Error: The memory file was not found!");
        }
    }

    internal bool WordIsKnown(string word)
    {
        return memoryBank.Memories.Contains(word);
    }

    private void PopulateMemoryBankFromFiles()
    {
        // If the path doesn't exist, then we do not need to populate the memory-bank as there are nothing to populate 
        // it with.
        if (EnsureMemoryPathExists())
        {
            var filePaths = Directory.GetFiles(instancePath);
            foreach (var filePath in filePaths)
            {
                if (Path.GetExtension(filePath) == ".json")
                {
                    var memoryName = Path.GetFileNameWithoutExtension(filePath);
                    memoryBank.Memories.Add(memoryName);
                }
            }
        }
    }

    private bool EnsureMemoryPathExists()
    {
        if (Directory.Exists(instancePath))
            return true;

        Directory.CreateDirectory(instancePath);
        return false;
    }
}