using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        ITable table = new FunctionalTable();
        IChair chair = new FunctionalChair();
        table.PrintType();
        chair.PrintType();
    }
}
