using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalFurnitureFactory : FurnitureFactory
{
    public override ITable CreateTable()
    {
        return new FunctionalTable();
    }

    public override IChair CreateChair()
    {
        return new FunctionalChair();
    }
}
