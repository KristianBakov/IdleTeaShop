using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _tabls;
    
    [SerializeField]
    private List<Sprite> _tablsSprites;
    
    private void Start()
    {
        BasicFurnitureFactory basicFurnitureFactory = new BasicFurnitureFactory();
        foreach (var table in _tabls)
        {
            IFurniture furniture = basicFurnitureFactory.CreateTable(table, new Vector3(2,1,20));
            furniture.PrintType();
        }
        
        foreach (var table in _tablsSprites)
        {
            IFurniture furniture = basicFurnitureFactory.CreateTable(table, Vector3.zero, Quaternion.identity);
            furniture.PrintType();
        }
        
    }
}
