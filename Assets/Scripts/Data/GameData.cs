using UnityEngine;

[System.Serializable]
public class GameData
{
    public uint bucks = 500;
    public uint diamonds = 50;
    public uint drinkVouchers = 2;
    
    public string username;
    
    public float musicVolume;
    public float sfxVolume;

    public GameData()
    {
        this.bucks = 500;
        this.diamonds = 50;
        this.drinkVouchers = 2;

        this.musicVolume = 80f;
        this.sfxVolume = 80f;

        this.username = "GUEST_123";
    }
    
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadJson(string jsonFilepath)
    {
        JsonUtility.FromJsonOverwrite(jsonFilepath, this);
    }
}
