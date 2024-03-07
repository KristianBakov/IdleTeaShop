using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DrinkState
{
    Preparing,
    Full,
    Empty
}
public class DrinkStateMachine : StateManager<DrinkState>
{
    protected string drinkName;
    protected Rarity rarity;
    public int cost;
    public float timeToMake;
    public float timeToDrink;
    public float happinessMultiplier;
    public Sprite sprite;
    
    private SpriteRenderer _spriteRenderer;
    DrinkStateMachine(string drinkNameIn, Sprite spriteIn, Rarity rarityIn)
    {
        drinkName = drinkNameIn;
        sprite = spriteIn;
    }
    
    
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if(_spriteRenderer) _spriteRenderer.sprite = sprite;
        //TODO: Remove this resize here
        transform.localScale = new Vector2(1f, 0.5f);
        
        States = new Dictionary<DrinkState, BaseState<DrinkState>>
        {
            { DrinkState.Preparing, new DrinkPreparingState(DrinkState.Preparing, this) },
            { DrinkState.Full, new DrinkFullState(DrinkState.Full, this) },
            { DrinkState.Empty, new DrinkEmptyState(DrinkState.Empty, this) }
        };
        CurrentState = States[DrinkState.Preparing];
    }
}
