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
    DrinkStateMachine(string drinkNameIn, Sprite spriteIn, Rarity rarityIn)
    {
        drinkName = drinkNameIn;
        sprite = spriteIn;
        
    }
    
    private void Awake()
    {
        States = new Dictionary<DrinkState, BaseState<DrinkState>>
        {
            { DrinkState.Preparing, new DrinkPreparingState(DrinkState.Preparing, this) },
            { DrinkState.Full, new DrinkFullState(DrinkState.Full, this) },
            { DrinkState.Empty, new DrinkEmptyState(DrinkState.Empty, this) }
        };
        CurrentState = States[DrinkState.Preparing];
    }
}
