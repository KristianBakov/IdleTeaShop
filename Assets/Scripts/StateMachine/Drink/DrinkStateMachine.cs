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
    protected string name;
    protected Rarity rarity;
    public int cost;
    public float timeToMake;
    public float timeToDrink;
    public float happinessMultiplier;
    public Sprite sprite;
    public Sprite emptySprite;
    DrinkStateMachine(string nameIn, Sprite spriteIn, Rarity rarityIn)
    {
        name = nameIn;
        sprite = spriteIn;
        
    }
    
    private void Awake()
    {
        States.Add(DrinkState.Preparing, new DrinkPreparingState(DrinkState.Preparing, this));
        States.Add(DrinkState.Full, new DrinkFullState(DrinkState.Full, this));
        States.Add(DrinkState.Empty, new DrinkEmptyState(DrinkState.Empty, this));
        CurrentState = States[DrinkState.Preparing];
    }
}
