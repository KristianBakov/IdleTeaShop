using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    public GameObject GoRef { get; set; }
    public Sprite SpriteRef { get; set; }
    public void OnPressed();
}
