using UnityEngine;

public abstract class FurnitureFactory
{
    public abstract ITable CreateTable(GameObject prefab, Vector3 position = default, Quaternion rotation = default);
    public abstract Chair CreateChair(GameObject prefab, Vector3 position = default, Quaternion rotation = default);
    public abstract ITable CreateTable(Sprite sprite, Vector3 position = default, Quaternion rotation = default);
    public abstract Chair CreateChair(Sprite sprite, Vector3 position = default, Quaternion rotation = default);
}
