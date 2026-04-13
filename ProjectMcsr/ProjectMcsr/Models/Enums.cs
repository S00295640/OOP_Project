namespace ProjectMcsr.Models;
public enum ResourceType
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
    Stronghold,
    End,
    Other,
}

public enum Difficulty
{
    Hardcore,
    Hard,
    Normal,
    Easy,
    Peaceful,
}

public enum SortBy
{
    Difficulty,
    Name,
    Type,
    Split,
    Date,
}

public static class EnumTools
{
    public static Split? StringToSplit(string type)
    {
        type = type.ToLower();
        if (type == "overworld")
            return Split.Overworld;
        if (type == "nether")
            return Split.EnterNether;
        if (type == "bastion")
            return Split.Bastion;
        if (type == "fortress")
            return Split.Fortress;
        if (type == "blind travel")
            return Split.Blind;
        if (type == "stronghold")
            return Split.Stronghold;
        if (type == "the end")
            return Split.End;
        if (type == "other")
            return Split.Other;
        return null;
    }

    public static SortBy? StringToSortBy(string type)
    {
        type = type.ToLower();
        if (type == "difficulty")
            return SortBy.Difficulty;
        if (type == "name")
            return SortBy.Name;
        if (type == "type")
            return SortBy.Type;
        if (type == "split")
            return SortBy.Split;
        if (type == "date")
            return SortBy.Date;
        
        return null;
    }

    public static ResourceType? StringToResourceType(string type)
    {
        type = type.ToLower();
        if (type == "tutorial")
            return ResourceType.Tutorial;
        if (type == "information")
            return ResourceType.Information;
        if (type == "other")
            return ResourceType.Other;
        return null;
    }
    
    public static Difficulty? StringToDifficulty(string type)
    {
        type = type.ToLower();
        if (type == "hardcore")
            return Difficulty.Hardcore;
        if (type == "hard")
            return Difficulty.Hard;
        if (type == "normal")
            return Difficulty.Normal;
        if (type == "easy")
            return Difficulty.Easy;
        if (type == "peaceful")
            return Difficulty.Peaceful;
        return null;
    }

    public static int DifficultyToInt(Difficulty? difficulty)
    {
        if (difficulty == Difficulty.Hardcore)
            return 5;
        if (difficulty == Difficulty.Hard)
            return 4;
        if (difficulty == Difficulty.Normal)
            return 3;
        if (difficulty == Difficulty.Easy)
            return 2;
        if (difficulty == Difficulty.Peaceful)
            return 1;
        return 0;
    }
}
