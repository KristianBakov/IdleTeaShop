using System;

public static class MainMenuUIEvents
{
    public static Action HomeScreenShown;
    public static Action SettingsScreenShown;
    public static Action SettingsScreenHidden;
    public static Action<string> CurrentViewChanged;
}
