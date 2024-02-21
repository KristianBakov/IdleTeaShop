using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    public GameObject PawnGameObject { get; protected set; }
    public Sprite PawnSprite { get; protected set; }
}
