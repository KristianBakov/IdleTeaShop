using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalFurnitureFactory : FurnitureFactory
{
    public override Table CreateTable(GameObject prefab)
    {
        FunctionalTable table = new FunctionalTable
        {
            Go = Object.Instantiate(prefab)
        };
        return table;
    }

    public override Chair CreateChair(GameObject prefab)
    {
        FunctionalChair chair = new FunctionalChair
        {
            Go = Object.Instantiate(prefab)
        };
        return chair;
    }

    public override Table CreateTable(Sprite sprite)
    {
        FunctionalTable table = new FunctionalTable
        {
            Go = new GameObject()
        };
        table.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return table;
    }

    public override Chair CreateChair(Sprite sprite)
    {
        FunctionalChair chair = new FunctionalChair
        {
            Go = new GameObject()
        };
        chair.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return chair;
    }
}
