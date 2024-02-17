using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFurnitureFactory : FurnitureFactory
{
    public override Table CreateTable(GameObject prefab)
    {
        BasicTable table = new BasicTable
        {
            Go = Object.Instantiate(prefab)
        };
        return table;
    }

    public override Chair CreateChair(GameObject prefab)
    {
        BasicChair chair = new BasicChair
        {
            Go = Object.Instantiate(prefab)
        };
        return chair;
    }

    public override Table CreateTable(Sprite sprite)
    { 
        BasicTable table = new BasicTable
        {
            Go = new GameObject()
        };
        table.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return table; 
    }

    public override Chair CreateChair(Sprite sprite)
    {
        BasicChair chair = new BasicChair
        {
            Go = new GameObject()
        };
        chair.Go.AddComponent<SpriteRenderer>().sprite = sprite;
        return chair;
    }
}