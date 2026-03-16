using System.Collections.Generic;
using System.Windows.Documents;
using ProjectMcsr.Models;

namespace ProjectMcsr;

public class MyResourceHandler
{
    public List<Ressource> Resources { get; }

    public void AddResource(Ressource? resource)
    {
        if (resource == null)
            throw new NullReferenceException();
        if (!Resources.Contains(resource))
            Resources.Add(resource);
    }

    public void RemoveResource(Ressource resource)
    {
        Resources.Remove(resource);
    }

    private void InitializeResources()
    {
        //Ajouter le chargement des Resources de l'utilisateur
    }

    public MyResourceHandler()
    {
        Resources = new List<Ressource>();
        InitializeResources();
    }

    public void UpdateMyResource()
    {
        foreach (Ressource resource in Resources)
        {
            
        }
    }
}