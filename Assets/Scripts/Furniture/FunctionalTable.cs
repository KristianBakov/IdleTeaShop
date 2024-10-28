using UnityEngine;

public class FunctionalTable : MonoBehaviour, ITable
{
    public int ID { get; set; }
    public bool IsEmpty { get; set; }

    public void PrintType()
    {
        Debug.Log("Functional Table");
    }

    public Vector2 GetWorldPosition()
    {
        return transform.position;
    }
}
