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

    public string iconPath
    {
        get
        {
            return split switch
            {
                Split.Overworld => "/Assets/Overworld.png",
                Split.EnterNether => "/Assets/Nether.png",
                Split.Bastion => "/Assets/Bastion.png",
                Split.Fortress => "/Assets/Fortress.png",
                Split.Blind => "/Assets/Blind.png",
                Split.Stronghold => "/Assets/Stronghold.png",
                Split.End => "/Assets/End.png",
                _ => "/Assets/Overworld.png" // (default hopefully never in this case if nothing broken)
            };
        }
    }

    public string EtoilesDifficulte
    {
        get
        {
            return difficulty switch
            {
                Difficulty.Peaceful => "★",
                Difficulty.Easy => "★★",
                Difficulty.Normal =>"★★★",
                Difficulty.Hard => "★★★★",
                Difficulty.Hardcore => "★★★★★",
                _ => "☆" // (default hopefully never in this case if nothing broken)
            };
        }
    }
    
    public Ressource(string author, string name,ResourceType? type,Difficulty? difficulty,string description,string? image,string? videoLink,Split? split)
    {
        if (name == "" || description == "" || videoLink == "" || type == null || difficulty == null || split == null)
        {
            throw new ArgumentNullException();
        }
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

        this.idVideo = $"https://img.youtube.com/vi/{idVideo}/maxresdefault.jpg";
    }

    public override string ToString()
    {
        return $"--------------------\n\rName : {name}\n\rDescription :\n\r{description}\n\rType : {type.ToString()}\n\rDifficulty : {difficulty.ToString()}\n\rVideo ID : {idVideo}\n\rSplit : {split.ToString()}\n\r--------------------";
    }

}