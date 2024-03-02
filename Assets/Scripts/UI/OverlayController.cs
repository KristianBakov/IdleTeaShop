using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class OverlayController : MonoBehaviour
{
    private UIDocument _mainMenuDocument;
    private UIView _currentView;
    private UIView _previousView;

    // List of all UIViews
    private List<UIView> _allViews = new List<UIView>();

    // Modal screens
    private UIView _homeView;  // Landing screen

    // Overlay screens
    private UIView _settingsView;  // Overlay screen for settings

    // Toolbars
    private UIView _menuBarView;  // Navigation bar for menu screens

    // VisualTree string IDs for UIViews; each represents one branch of the tree
    public const string HomeViewName = "HomeScreen";
    public const string SettingsViewName = "SettingsScreen";

    public UIDocument MainMenuDocument => _mainMenuDocument;

    private void OnEnable()
    {
        _mainMenuDocument = GetComponent<UIDocument>();

        SetupViews();

        SubscribeToEvents();

        // Start with the home screen
        ShowModalView(_homeView);
    }

    private void SubscribeToEvents()
    {

        MainMenuUIEvents.HomeScreenShown += OnHomeScreenShown;
        
        MainMenuUIEvents.SettingsScreenShown += OnSettingsScreenShown;
        MainMenuUIEvents.SettingsScreenHidden += OnSettingsScreenHidden;
    }

    private void OnDisable()
    {
        UnsubscribeFromEvents();

        foreach (UIView view in _allViews)
        {
            view.Dispose();
        }
    }

    private void UnsubscribeFromEvents()
    {

        MainMenuUIEvents.HomeScreenShown -= OnHomeScreenShown;
        
        MainMenuUIEvents.SettingsScreenShown -= OnSettingsScreenShown;
        MainMenuUIEvents.SettingsScreenHidden -= OnSettingsScreenHidden;
    }
    
    void Start()
    {
        Time.timeScale = 1f;
    }



}
