using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    public abstract GameObject GetGoRef();
    public abstract Sprite GetSpriteRef();
    public void OnPressed();
}
