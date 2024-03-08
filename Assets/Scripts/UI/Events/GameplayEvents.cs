using System;

public class GameplayEvents : MonoSingleton<GameplayEvents>
{
    public static Action<GameData> SettingsUpdated;

    // Use the gameData to load the music and sfx volume levels
    public static Action SettingsLoaded;

    // Adjust the music volume during gameplay
    public static Action<float> MusicVolumeChanged;

    // Adjust the sound effects volume during gameplay
    public static Action<float> SfxVolumeChanged;
}
