using System.Text.Json;

namespace AiCompanion.Memory;

internal class MemoryFragmentSystem
{
    private const string basePath = "AiMemories/";
    private readonly JsonSerializerOptions serializeAllFields = new() {IncludeFields = true};
    
    private string entityName;
    private readonly string instancePath;

    private MemoryBank memoryBank = new();
    
    internal MemoryFragmentSystem(string entityName)
    {
        this.entityName = entityName;
        instancePath = basePath + entityName + "/";
        PopulateMemoryBankFromFiles();
    }
    
    internal void SaveMemoryFragment(Memory memory)
    {
        var path = instancePath + memory.Title + ".json";
        string json = JsonSerializer.Serialize(memory, serializeAllFields);
        File.WriteAllText(path, json);
    }

    internal Memory GetMemoryFromPath(string memoryTitle)
    {
        var pathToFile = instancePath + memoryTitle + ".json";
        throw new NotImplementedException();
    }

    private void PopulateMemoryBankFromFiles()
    {
        // If the path doesn't exist, then we do not need to populate the memory-bank as there are nothing to populate 
        // it with.
        if (EnsureMemoryPathExists())
        {
            var files = Directory.GetFiles(instancePath);
            foreach (var file in files)
            {
                Console.WriteLine(file);
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