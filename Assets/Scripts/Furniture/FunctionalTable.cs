using UnityEngine;

public class FunctionalTable : Table
{
    public override void PrintType()
    {
        Debug.Log("Functional Table");
    }

    public override Vector2 GetWorldPosition()
    {
        return Go.transform.position;
    }
}
