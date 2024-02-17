using UnityEngine;

public abstract class FurnitureFactory
{
    public abstract Table CreateTable(GameObject prefab);
    public abstract Chair CreateChair(GameObject prefab);
    public abstract Table CreateTable(Sprite sprite);
    public abstract Chair CreateChair(Sprite sprite);
}
