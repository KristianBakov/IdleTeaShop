using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomer : MonoBehaviour, ITargetable
{
    private GameObject _goRef;
    private Sprite _spriteRef;

    public GameObject GoRef
    {
        get => _goRef;
        set => _goRef = value;
    }
    
    public Sprite SpriteRef
    {
        get => _spriteRef;
        set => _spriteRef = value;
    }

    private void Awake()
    {
        _goRef = gameObject;
        _spriteRef = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseDown()
    {
        OnPressed();
    }

    public void OnPressed()
    {
        Debug.Log("Pressed on " + GoRef.name + " with sprite " + SpriteRef.name + "!");
    }
}
