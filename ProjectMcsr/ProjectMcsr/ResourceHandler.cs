using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using ProjectMcsr.Models;
using System.Text.Json;
namespace ProjectMcsr;

public class MyResourceHandler
{

    private string _pathToSave = "./Resources/ressources.json";
    public List<Ressource> Resources { get; private set; }

    public void AddResource(Ressource? resource)
    {
        if (resource == null)
            throw new NullReferenceException();
        if (!Resources.Contains(resource))
            Resources.Add(resource);
        SortResourcesBy(SortBy.Name);
    }

    public void RemoveResource(Ressource resource)
    {
        Resources.Remove(resource);
    }

    public void SaveResources()
    {
        string? directoryPath = Path.GetDirectoryName(_pathToSave);
        
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        
        string jsonSring = JsonSerializer.Serialize(Resources);
        File.WriteAllText(_pathToSave, jsonSring);
    }

    private List<Ressource> InitializeResources()
    {
        if (!File.Exists(_pathToSave))
            return new List<Ressource>();
        try
        {
            string jsonSring = File.ReadAllText(_pathToSave);
            return JsonSerializer.Deserialize<List<Ressource>>(jsonSring) ?? new List<Ressource>();
        }
        catch
        {
            return new List<Ressource>();
        }
    }

    public void SortResourcesBy(SortBy sortBy)
    {
        IOrderedEnumerable<Ressource> query = Resources.OrderBy(r => r.name);
        switch (sortBy)
        {
            case SortBy.Name:
                query = Resources.OrderBy(r => r.name);
                break;
            case SortBy.Date:
                query = Resources.OrderBy(r => r.Date);
                break;
            case SortBy.Difficulty:
                query = Resources.OrderBy(r => r.difficulty);
                break;
            case SortBy.Type:
                query = Resources.OrderBy(r => r.type);
                break;
            case SortBy.Split:
                query = Resources.OrderBy(r => r.split);
                break;
        }
        Resources = query.ToList();
        
    }

    public MyResourceHandler()
    {
        Resources = InitializeResources();
        SortResourcesBy(SortBy.Name);
    }
    
    
}