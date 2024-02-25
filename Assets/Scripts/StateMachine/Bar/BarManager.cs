using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    [SerializeField] 
    private List<DrinkSO> drinks;

    public List<DrinkSO> Drinks => drinks;

    private void Awake()
    {
        drinks = new List<DrinkSO>();
    }

    public void AddDrink(DrinkSO drink)
    {
        drinks.Add(drink);
    }

    public void RemoveDrink(DrinkSO drink)
    {
        drinks.Remove(drink);
    }
    
    public void RemoveDrink(int index)
    {
        drinks.RemoveAt(index);
    }
    
    void StartBrewingDrink(DrinkSO drink)
    {
        //instantiate a drink object in the scene with drinkSo properties
        
        //DrinkStateMachine drinkSM = new DrinkStateMachine();
    }
}
