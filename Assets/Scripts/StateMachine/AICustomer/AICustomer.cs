using UnityEngine;

public class AICustomer : MonoBehaviour, ITargetable
{
    private GameObject _goRef;
    private Sprite _spriteRef;
    

    private void Awake()
    {
        _goRef = gameObject;
        _spriteRef = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseDown()
    {
        OnPressed();
    }

    public GameObject GetGoRef()
    {
        if(_goRef == null)
        {
            _goRef = gameObject;
        }
        return _goRef;
    }

    public Sprite GetSpriteRef()
    {
        if(_spriteRef == null)
        {
            _spriteRef = GetComponent<SpriteRenderer>().sprite;
        }
        return _spriteRef;
    }

    public void OnPressed()
    {
        Debug.Log("Pressed on " + GetGoRef().name + " with sprite " + GetSpriteRef().name + "!");
    }
}
