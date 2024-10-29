using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Table : IFurniture
{
    public GameObject Go { get; set; }
    public int ID { get; set; }
    public bool IsEmpty { get; set; }
    public abstract void PrintType();
    public abstract Vector2 GetWorldPosition();
}
