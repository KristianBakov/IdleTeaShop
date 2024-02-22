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
}
