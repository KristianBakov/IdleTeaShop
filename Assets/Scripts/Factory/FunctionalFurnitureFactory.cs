using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalFurnitureFactory : FurnitureFactory
{
    public override Table CreateTable(GameObject prefab, Vector3 position = default, Quaternion rotation = default)
    {
        FunctionalTable table = new FunctionalTable
        {
            Go = Object.Instantiate(prefab, position, rotation)
        };
        return table;
    }

    public override Chair CreateChair(GameObject prefab, Vector3 position = default, Quaternion rotation = default)
    {
        FunctionalChair chair = new FunctionalChair
        {
            Go = Object.Instantiate(prefab, position, rotation)
        };
        return chair;
    }

    public override Table CreateTable(Sprite sprite, Vector3 position = default, Quaternion rotation = default)
    {
        FunctionalTable table = new FunctionalTable
        {
            Go = new GameObject
            {
                transform =
                {
                    position = position,
                    rotation = rotation
                }
            },
        };
        table.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return table;
    }

    public override Chair CreateChair(Sprite sprite, Vector3 position = default, Quaternion rotation = default)
    {
        FunctionalChair chair = new FunctionalChair
        {
            Go = new GameObject
            {
                transform =
                {
                    position = position,
                    rotation = rotation
                }
            },
        };
        chair.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return chair;
    }
}
