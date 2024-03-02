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
    private UIView _shopView;  // Shop screen

    // Overlay screens
    private UIView _settingsView;  // Overlay screen for settings

    // Toolbars
    private UIView _menuBarView;  // Navigation bar for menu screens

    // VisualTree string IDs for UIViews; each represents one branch of the tree
    public const string HomeViewName = "HomeScreen";
    public const string SettingsViewName = "SettingsScreen";
    public const string ShopViewName = "ShopScreen";
    public const string MenuBarViewName = "MenuBar";

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

    private void SetupViews()
    {
        VisualElement root = _mainMenuDocument.rootVisualElement;

        // Create full-screen modal views: HomeView, CharView, InfoView, ShopView, MailView
        _homeView = new HomeView(root.Q<VisualElement>(HomeViewName)); // Landing modal screen
        _shopView = new ShopView(root.Q<VisualElement>(ShopViewName)); // Shop screen

        // Overlay views (popup modal with background)
        _settingsView = new SettingsView(root.Q<VisualElement>(SettingsViewName)); // Game settings overlay

        // Toolbars 
        _menuBarView = new MenuBarView(root.Q<VisualElement>(MenuBarViewName)); // Screen selection toolbar


        // Track modal UI Views in a List for disposal 
        _allViews.Add(_homeView);
        _allViews.Add(_shopView);
        _allViews.Add(_settingsView);
        _allViews.Add(_menuBarView);

        // UI Views enabled by default
        _homeView.Show();
        _menuBarView.Show();
    }

    private void ShowModalView(UIView newView)
    {
        _currentView?.Hide();

        _previousView = _currentView;
        _currentView = newView;

        // Show the screen and notify any listeners that the main menu has updated

        if (_currentView != null)
        {
            _currentView.Show();
            MainMenuUIEvents.CurrentViewChanged?.Invoke(_currentView.GetType().Name);
        }
    }

    private void OnHomeScreenShown()
    {
        ShowModalView(_homeView);
    }

    private void OnSettingsScreenShown()
    {
        _previousView = _currentView;
        _settingsView.Show();
    }

    private void OnSettingsScreenHidden()
    {
        _settingsView.Hide();

        if (_previousView != null)
        {
            _previousView.Show();
            _currentView = _previousView;
            MainMenuUIEvents.CurrentViewChanged?.Invoke(_currentView.GetType().Name);
        }
    }

}
