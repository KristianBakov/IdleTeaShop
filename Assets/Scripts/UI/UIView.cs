using System;
using UnityEngine.UIElements;

/// <summary>
/// This is a base class for a functional unit of the UI. This can make up a full-screen interface or just
/// part of one.
/// </summary>
public abstract class UIView : IDisposable
{
    protected bool hideOnAwake = true;

    // UI reveals other underlaying UIs, partially see-through
    protected bool isOverlay;

    protected VisualElement topElement;

    // Properties
    public VisualElement Root => topElement;
    public bool IsTransparent => isOverlay;
    public bool IsHidden => topElement.style.display == DisplayStyle.None;

    // Constructor
    /// <summary>
    /// Initializes a new instance of the UIView class.
    /// </summary>
    /// <param name="topElement">The topmost VisualElement in the UXML hierarchy.</param>
    public UIView(VisualElement topElement)
    {
        this.topElement = topElement ?? throw new ArgumentNullException(nameof(topElement));
        Initialize();
    }

    public virtual void Initialize()
    {
        if (hideOnAwake)
        {
            Hide();
        }

        SetVisualElements();
        RegisterButtonCallbacks();
    }

    // Sets up the VisualElements for the UI. Override to customize.
    protected virtual void SetVisualElements()
    {

    }

    // Registers callbacks for buttons in the UI. Override to customize.
    protected virtual void RegisterButtonCallbacks()
    {

    }

    // Displays the UI.
    public virtual void Show()
    {
        topElement.style.display = DisplayStyle.Flex;
    }

    // Hides the UI.
    public virtual void Hide()
    {
        topElement.style.display = DisplayStyle.None;
    }

    // Unregisters any callbacks or event handlers. Override to customize.
    public virtual void Dispose()
    {

    }
}
