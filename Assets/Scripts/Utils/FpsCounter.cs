using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FpsCounter : MonoBehaviour
{
    private const int TargetFrameRate = 60; // 60 for mobile platforms, -1 for fast as possible
    private const int BufferSize = 50; // Number of frames to sample

    [SerializeField] private UIDocument document;
    [SerializeField] private bool isEnabled;

    private float _fpsValue;
    private int _currentIndex;
    private float[] _deltaTimeBuffer;

    private Label _fpsLabel;

    public float FpsValue => _fpsValue;

    // MonoBehaviour event messages
    private void Awake()
    {
        _deltaTimeBuffer = new float[BufferSize];
        Application.targetFrameRate = TargetFrameRate;
    }

    private void OnEnable()
    {
        //SettingsEvents.FpsCounterToggled += OnFpsCounterToggled;
        //SettingsEvents.TargetFrameRateSet += OnTargetFrameRateSet;

        var root = document.rootVisualElement;
        _fpsLabel = root.Q<Label>("fps-counter");

        if (_fpsLabel != null) return;
        Debug.LogWarning("[FPSCounter]: Display label is null.");
    }

    void OnDisable()
    {
        //SettingsEvents.FpsCounterToggled -= OnFpsCounterToggled;
        //SettingsEvents.TargetFrameRateSet -= OnTargetFrameRateSet;
    }

    private void Update()
    {
        if (!isEnabled) return;
        _deltaTimeBuffer[_currentIndex] = Time.deltaTime;
        _currentIndex = (_currentIndex + 1) % _deltaTimeBuffer.Length;
        _fpsValue = Mathf.RoundToInt(CalculateFps());

        _fpsLabel.text = $"FPS: {_fpsValue}";
    }

    // Methods
    private float CalculateFps()
    {
        float totalTime = _deltaTimeBuffer.Sum();
        return _deltaTimeBuffer.Length / totalTime;
    }

    // Event-handling methods
    private void OnFpsCounterToggled(bool state)
    {
        isEnabled = state;
        _fpsLabel.style.visibility = (state) ? Visibility.Visible : Visibility.Hidden;
    }

    // Set the target frame rate:  -1 = as fast as possible (PC) or 60/30 fps (mobile) 
    private void OnTargetFrameRateSet(int newFrameRate)
    {
        Application.targetFrameRate = newFrameRate;
    }
}
