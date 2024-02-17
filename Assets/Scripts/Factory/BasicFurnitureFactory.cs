using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFurnitureFactory : FurnitureFactory
{
    public override ITable CreateTable()
    {
        return new BasicTable();
    }

    public override IChair CreateChair()
    {
        return new BasicChair();
    }
}