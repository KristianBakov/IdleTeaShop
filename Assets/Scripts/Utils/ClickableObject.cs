using System;
using UnityEngine;

public class ClickableObject : MonoBehaviour, ITargetable
{
    private Action OnPressedAction;
    
    public void OnPressed()
    {
        OnPressedAction?.Invoke();
    }

    protected void AddListener(Action action)
    {
        OnPressedAction += action;
    }

    protected void RemoveListener(Action action)
    {
        OnPressedAction -= action;
    }

    private void OnMouseDown()
    {
        OnPressed();
    }
}
