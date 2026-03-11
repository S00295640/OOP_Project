namespace ProjectMcsr.Models;


public enum RessourceType
{
    Tutorial,
    Information,
    Other,
}

public enum Split
{
    Overworld,
    EnterNether,
    Bastion,
    Fortress,
    Blind,
    End,
    Other,
}

public class Ressource
{
    public string author { get; set; }
    public string name { get; set; }
    public RessourceType type { get; set; }
    public int difficulty { get; set; }
    public string description { get; set; }
    public string? image { get; set; }
    public string? idVideo { get; set; }
    public Split? split { get; set; }
    
    public Ressource(string author, string name,RessourceType type,int difficulty,string description,string? image,string? videoLink,Split? split)
    {
        this.author = author;
        this.name = name;
        this.type = type;
        this.difficulty = difficulty;
        this.description = description;
        this.image = image;
        this.split = split;
        if (videoLink == null) return;
        if (videoLink.Contains("youtube.com") || videoLink.Contains("youtu.be"))
        {
            this.idVideo = videoLink.Split('v', '=', '/').Last();
        }
    }

}