using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
     [SerializeField]
    private List<GameObject> tabls;
    
    [SerializeField]
    private List<Sprite> tablsSprites;
    
    private void Start()
    {
        // BasicFurnitureFactory basicFurnitureFactory = new BasicFurnitureFactory();
        // foreach (var table in tabls)
        // {
        //     IFurniture furniture = basicFurnitureFactory.CreateTable(table, new Vector3(2,1,20));
        //     furniture.PrintType();
        // }
        //
        // foreach (var table in tablsSprites)
        // {
        //     IFurniture furniture = basicFurnitureFactory.CreateTable(table, Vector3.zero, Quaternion.identity);
        //     furniture.PrintType();
        // }
        
    }
}
