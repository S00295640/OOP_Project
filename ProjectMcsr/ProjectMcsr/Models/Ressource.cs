using System.Diagnostics.CodeAnalysis;

namespace ProjectMcsr.Models;



public class Ressource
{
    public string author { get; set; }
    public string name { get; set; }
    public ResourceType? type { get; set; }
    public Difficulty? difficulty { get; set; }
    public string description { get; set; }
    public string? image { get; set; }
    public string? idVideo { get; set; }
    public Split? split { get; set; }
    
    public Ressource(string author, string name,ResourceType? type,Difficulty? difficulty,string description,string? image,string? videoLink,Split? split)
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

    public override string ToString()
    {
        return $"--------------------\n\rName : {name}\n\rDescription :\n\r{description}\n\rType : {type.ToString()}\n\rDifficulty : {difficulty.ToString()}\n\rVideo ID : {idVideo}\n\rSplit : {split.ToString()}\n\r--------------------";
    }

}