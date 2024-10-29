using UnityEngine;

public class BasicTable : Table
{
    public override void PrintType()
    {
        Debug.Log("Basic Table");
    }

    public override Vector2 GetWorldPosition()
    {
        return Go.transform.position;
    }
}
