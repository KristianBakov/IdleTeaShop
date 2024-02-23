using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveManager))]
public class GameDataManager : MonoBehaviour
{
    [SerializeField] GameData m_GameData;
    
    public GameData GameData { set => m_GameData = value; get => m_GameData; }

    SaveManager m_SaveManager;
    bool m_IsGameDataInitialized;

    public void SetUsername(string username)
    {
        GameData.username = username;
        m_SaveManager.SaveGame();
    }

    void Awake()
    {
        m_SaveManager = GetComponent<SaveManager>();
    }

    private void Start()
    {
        //load if saved data exists 
        m_SaveManager.LoadGame();
        
        m_IsGameDataInitialized = true;
        
        //TODO: Show welcome message
        Debug.Log("Hey " + GameData.username);
    }
    
    
}
