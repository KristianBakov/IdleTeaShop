using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCustomer : MonoBehaviour
{
    
    private void OnEnable()
    {
        EventManager.StartListening(BarEvent.TestingEvent.ToString(), SayThanks);
    }

    private void OnDisable()
    {
        EventManager.StopListening(BarEvent.TestingEvent.ToString(), SayThanks);
    }
    
    private void SayThanks(Dictionary<string, object> message)
    {
        var amount = (int) message["amount"];
        //Debug.Log("Thanks for the " + amount + " drinks!");
    }
}
