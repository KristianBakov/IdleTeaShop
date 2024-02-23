using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Switch from json to MessagePack (https://msgpack.org/index.html) or Protocol Buffers (https://developers.google.com/protocol-buffers)
[RequireComponent(typeof(GameDataManager))]
public class SaveManager : MonoBehaviour
{
    public static event Action<GameData> GameDataLoaded;

    [Tooltip("Filename to save game and settings data")]
    [SerializeField] string m_SaveFilename = "idleteashopsave.dat";
    [Tooltip("Show Debug messages.")]
    [SerializeField] bool m_Debug = true;
    
    GameDataManager m_GameDataManager;

    private void Awake()
    {
        m_GameDataManager = GetComponent<GameDataManager>();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public GameData NewGame()
    {
        return new GameData();
    }
    
    public void LoadGame()
    {
        // load saved data from FileDataHandler

        if (m_GameDataManager.GameData == null)
        {
            if (m_Debug)
            {
                Debug.Log("GAME DATA MANAGER LoadGame: Initializing game data.");
            }

            m_GameDataManager.GameData = NewGame();
        }
        else if (FileManager.LoadFromFile(m_SaveFilename, out var jsonString))
        {
            m_GameDataManager.GameData.LoadJson(jsonString);

            if (m_Debug)
            {
                Debug.Log("SaveManager.LoadGame: " + m_SaveFilename + " json string: " + jsonString);
            }
        }

        // notify other game objects 
        if (m_GameDataManager.GameData != null)
        {
            GameDataLoaded?.Invoke(m_GameDataManager.GameData);
        }
    }
    
    
    public void SaveGame()
    {
        string jsonFile = m_GameDataManager.GameData.ToJson();

        // save to disk with FileDataHandler
        if (FileManager.WriteToFile(m_SaveFilename, jsonFile) && m_Debug)
        {
            Debug.Log("SaveManager.SaveGame: " + m_SaveFilename + " json string: " + jsonFile);
        }
    }
    
    void OnSettingsShown()
    {
        if (m_GameDataManager.GameData != null)
        {
            GameDataLoaded?.Invoke(m_GameDataManager.GameData);
        }
    }

    // Update the GameDataManager data and save
    void OnSettingsUpdated(GameData gameData)
    {
        m_GameDataManager.GameData = gameData;
        SaveGame();
    }
    
    // void OnEnable()
    // {
    // SettingsEvents.SettingsShown += OnSettingsShown;
    // SettingsEvents.SettingsUpdated += OnSettingsUpdated;
    //
    // GameplayEvents.SettingsUpdated += OnSettingsUpdated;
    // }

    // void OnDisable()
    // {
    // SettingsEvents.SettingsShown -= OnSettingsShown;
    // SettingsEvents.SettingsUpdated -= OnSettingsUpdated;
    //
    // GameplayEvents.SettingsUpdated -= OnSettingsUpdated;
    //
    // }
    
}
