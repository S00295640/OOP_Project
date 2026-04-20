using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    public string? OnlyIdVideo  { get; set; }
    //public List<Split?> splits { get; set; }
    public Split? split { get; set; }
    public float note { get; set; }
    public DateTime date { get; set; }
    

    //Maybe adding Some tags Later
    //A Tag class is Created but is useless for the moment
    //Think about it later during the "Search For Resources" part
    /* public List<Tag>? tags { get; set; }*/

    /*public List<string> iconsPath
    {
        get
        {
            List<string> icons = new List<string>();
            foreach (Split? split in this.split)
            {
                icons.Add(split switch
                {
                    Split.Overworld => "/Assets/Overworld.png",
                    Split.EnterNether => "/Assets/Nether.png",
                    Split.Bastion => "/Assets/Bastion.png",
                    Split.Fortress => "/Assets/Fortress.png",
                    Split.Blind => "/Assets/Blind.png",
                    Split.Stronghold => "/Assets/Stronghold.png",
                    Split.End => "/Assets/End.png",
                    _ => "/Assets/Overworld.png" // (default hopefully never in this case if nothing broken)
                });
            }
            return icons;
        }
    }*/
    
    /*public List<string> iconsPath
    {
        get
        {
            List<string> icons = new List<string>();
            foreach (Split? split in this.split)
            {
                icons.Add(split switch
                {
                    Split.Overworld => "/Assets/Overworld.png",
                    Split.EnterNether => "/Assets/Nether.png",
                    Split.Bastion => "/Assets/Bastion.png",
                    Split.Fortress => "/Assets/Fortress.png",
                    Split.Blind => "/Assets/Blind.png",
                    Split.Stronghold => "/Assets/Stronghold.png",
                    Split.End => "/Assets/End.png",
                    _ => "/Assets/Overworld.png" // (default hopefully never in this case if nothing broken)
                });
            }
            return icons;
        }
    }*/
    
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
    
    public IEnumerable DiffNumber
    {
        get
        {
            int count =  difficulty switch
            {
                Difficulty.Peaceful =>1,
                Difficulty.Easy => 2,
                Difficulty.Normal =>3,
                Difficulty.Hard => 4,
                Difficulty.Hardcore => 5,
                _ =>0 // (default hopefully never in this case if nothing broken)
            };
            return Enumerable.Range(0, count);
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
    
    public Ressource() 
    {
        //For the json save ?
    }
    
    public Ressource(string author, string name,ResourceType? type,Difficulty? difficulty,string description,string? image,string? videoLink,Split? split)
    {
        //this.splits = new List<Split?>();
        if (name == "" || type == null || difficulty == null || split == null)
        {
            throw new ArgumentNullException();
        }
        this.author = author;
        this.name = name;
        this.type = type;
        this.difficulty = difficulty;
        this.description = description;
        this.image = image;
        //this.splits.Add(split);
        this.split = split;
        this.note = 50;
        if (videoLink == null) return;
        if (videoLink.Contains("youtube.com") || videoLink.Contains("youtu.be"))
        {
            if (videoLink.Contains("&"))
            {
                string[] tmp = videoLink.Split('v', '=', '/','&');    
                this.idVideo = tmp[tmp.Length - 3];
                Console.WriteLine("id :" + idVideo + "---" + "\n");
            }
            else
                this.idVideo = videoLink.Split('v', '=', '/','&').Last();
        }
        this.OnlyIdVideo = idVideo;
        this.idVideo = $"https://img.youtube.com/vi/{idVideo}/maxresdefault.jpg";
    }
    
    
    public async void GetChannelNameAndDate()
    {
        using (HttpClient client = new HttpClient())
        {
            string oEmbedUrl = $"https://www.youtube.com/oembed?url=https://www.youtube.com/watch?v={this.OnlyIdVideo}&format=json";
        
            try 
            {
                
                //Name 
                string json = await client.GetStringAsync(oEmbedUrl);
            
                
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    JsonElement root = doc.RootElement;
                    this.author = root.GetProperty("author_name").GetString();
                }
                
                //Date with WebScrapping
                
                string url = $"https://www.youtube.com/watch?v={this.OnlyIdVideo}";
                string html = await client.GetStringAsync(url);
                try
                {
                    var match = Regex.Match(html, "itemprop=\"uploadDate\" content=\"(.*?)\"");
                    if (match.Success)
                    {
                        string dateString = match.Groups[1].Value;
                        if (DateTime.TryParse(dateString, out DateTime date))
                        {
                            this.date = date;
                        }
                    }
                
                }
                catch (Exception e)
                {
                    this.date = DateTime.MinValue;
                }


            }
            catch
            {
                this.author = "Unknown";
            }
        }
    }
    
    
    //Failed to use yt Dislike Api to get likes ratio
    /*
    public async Task<int> GetVideoStats()
    {
        //Using Api of the dislike yt extension
        
        using (HttpClient client = new HttpClient())
        {
            
            string url = $"https://returnyoutubedislikeapi.com/votes?videoId={OnlyIdVideo}";

            try
            {
                Console.WriteLine("Connecting to youtube dislike api...\n");
                string json = await client.GetStringAsync(url);
                Console.WriteLine("Parsing...\n");
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    int likes = doc.RootElement.GetProperty("likes").GetInt32();
                    int dislikes = doc.RootElement.GetProperty("dislikes").GetInt32();
                    Console.WriteLine("Likes: " + likes);
                    return likes / (likes + dislikes) * 100;
                }
            }
            catch
            {
                return 0;
            }
        }
    }*/
    
    
    

    public override string ToString()
    {
        return $"--------------------\n\rName : {name} \n\rAuthor : {author}\n\rDescription :\n\r{description}\n\rType : {type.ToString()}\n\rDifficulty : {difficulty.ToString()}\n\rVideo ID : {idVideo} /{OnlyIdVideo}/\n\rSplit : {split.ToString()}\n\r--------------------";
    }

}