using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Table : IFurniture
{
    public GameObject Go { get; set; }
    public abstract void PrintType();
}
