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
        if (type == "end")
            return Split.End;
        if (type == "other")
            return Split.Other;
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
}
