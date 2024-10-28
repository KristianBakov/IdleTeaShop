using UnityEngine;

public class BasicTable : MonoBehaviour, ITable
{
    public int ID { get; set; }
    public bool IsEmpty { get; set; }

    public void PrintType()
    {
        Debug.Log("Basic Table");
    }

    public Vector2 GetWorldPosition()
    {
        return transform.position;
    }
}
