using System;
using UnityEngine;

public class AICustomer : ClickableObject
{
    private void OnEnable()
    {
        AddListener(CustomerPressed);
    }

    private void OnDisable()
    {
        RemoveListener(CustomerPressed);
    }

    private void CustomerPressed()
    {
        //TODO: Show customer details widget
        Debug.Log("I am pressed" + gameObject.name);
    }
}
