using UnityEngine;


public enum Rarity
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Assets/Resources/GameData/Drinks/DrinkGameData", menuName = "IdleTeaShop/Drink")]
public class DrinkSO : ScriptableObject
{
    public string drinkName;
    public Rarity rarity;
    public int cost;
    public float timeToMake;
    public float timeToDrink;
    public float happinessMultiplier;
    public Sprite sprite;
    public Sprite emptySprite;
}
