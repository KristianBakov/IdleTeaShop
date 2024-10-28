using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public List<ITable> tables;

    private void Start()
    {
        //TODO: Make this dynamic

        List<GameObject> tempTableGos = new List<GameObject>();
        tempTableGos.AddRange(GameObject.FindGameObjectsWithTag("Table"));

        tables = new List<ITable>();
        foreach (var tableGo in tempTableGos)
        {
            tables.Add(tableGo.GetComponent<ITable>());
        }
    }

    Vector2 GetBestEmptyTablePosition()
    {
        //Get positions of all tables
        foreach (var table in tables.Where(table => !table.IsEmpty))
        {
            return table.GetWorldPosition();
        }

        return Vector2.zero;
    }

}
