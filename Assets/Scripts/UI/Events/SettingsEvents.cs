using System;

public class SettingsEvents : MonoSingleton<SettingsEvents>
{
    public static Action SettingsShown;
    public static Action<GameData> SettingsUpdated;
    
    public static Action<bool> FpsCounterToggled;
}
