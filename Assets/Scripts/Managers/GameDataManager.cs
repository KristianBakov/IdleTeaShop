using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SaveManager))]
public class GameDataManager : MonoBehaviour
{
    [SerializeField] 
    private GameData gameData;
    
    public GameData GameData { set => gameData = value; get => gameData; }

    private SaveManager _saveManager;
    private bool _isGameDataInitialized;

    public void SetUsername(string username)
    {
        GameData.username = username;
        _saveManager.SaveGame();
    }

    void Awake()
    {
        _saveManager = GetComponent<SaveManager>();
    }

    private void Start()
    {
        //load if saved data exists 
        _saveManager.LoadGame();
        
        _isGameDataInitialized = true;
        
        //TODO: Show welcome message
        Debug.Log("Hey " + GameData.username);
    }
    
    
}
