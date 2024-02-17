using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BasicFurnitureFactory : FurnitureFactory
{
    public override Table CreateTable(GameObject prefab, Vector3 position = default, Quaternion rotation = default)
    {
        BasicTable table = new BasicTable
        {
            Go = Object.Instantiate(prefab, position, rotation)
        };
        return table;
    }

    public override Chair CreateChair(GameObject prefab, Vector3 position = default, Quaternion rotation = default)
    {
        BasicChair chair = new BasicChair
        {
            Go = Object.Instantiate(prefab, position, rotation)
        };
        return chair;
    }

    public override Table CreateTable(Sprite sprite, Vector3 position = default, Quaternion rotation = default)
    { 
        BasicTable table = new BasicTable
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
        BasicChair chair = new BasicChair
        {
            Go = new GameObject
            {
                transform =
                {
                    position = position,
                    rotation = rotation
                }
            }
        };
        chair.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return chair;
    }
}