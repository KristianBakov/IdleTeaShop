using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarEvent
{
    TestingEvent

}

public class Bar : MonoBehaviour
{
    private int _numOfDrinks;

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         //Debug.Log("Adding a drink");
    //         AddDrinks(new Dictionary<string, object> { { "amount", _numOfDrinks++ } });
    //     }
    // }

    private void AddDrinks(Dictionary<string, object> message)
    {
        EventManager.TriggerEvent(BarEvent.TestingEvent.ToString(), message);
    }
}
