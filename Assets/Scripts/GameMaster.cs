using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Utilities;

public class GameMaster : MonoBehaviour {

    private const string saveFileName = "/test2.save";

    public Castle castle;
    public Spell[] spells;


    public static GameMaster Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            //Debug.Log("You try to create more than 1 Game Master!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (LoadPlayerData())
        {
            SetPlayerData();
        }
        else
        {
            StartNewGame();
            SetPlayerData();
        }
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOverMenu();

        SavePlayerData();
    }

    public void RestartGame()
    {
        SavePlayerData();
        SceneManager.LoadScene("Game");
        ResumeGame();
        SetPlayerData();
    }

    public void PauseGame()
    {
        SavePlayerData();
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void StartNewGame()
    {
        //set player stats to default
        PlayerStats.money = 0;

        PlayerStats.castleMaxHP = castle.maxHealth;
        PlayerStats.castleMaxShield = castle.maxShield;
        PlayerStats.castleShieldRecovery = castle.shieldRecovery;

        PlayerStats.spellsStats = new SpellStats[spells.Length];
        for (int i = 0; i < spells.Length; i++)
        {
            PlayerStats.spellsStats[i] = spells[i].stats;
        }
    }

    //set saved player stats to game
    public void SetPlayerData()
    {
        castle.GetComponent<Castle>().maxHealth = PlayerStats.castleMaxHP;
        castle.GetComponent<Castle>().maxShield = PlayerStats.castleMaxShield;

        //debug
        if (PlayerStats.spellsStats == null) Debug.Log("ps spells is null");

        for(int i = 0; i < spells.Length; i++)
        {
            spells[i].stats = PlayerStats.spellsStats[i];
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.money = PlayerStats.money;

        if (PlayerStats.spellsStats == null)
        {
            for (int i = 0; i < spells.Length; i++)
            {
                save.spellsStats[i] = spells[i].stats;
            }
        }
        else
        {
            save.spellsStats = PlayerStats.spellsStats;
        }

        save.castleMaxHP = PlayerStats.castleMaxHP;
        save.castleMaxShield = PlayerStats.castleMaxShield;
        save.castleShieldRecovery = PlayerStats.castleShieldRecovery;

        return save;
    }

    public void SavePlayerData()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveFileName);
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public bool LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFileName, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            PlayerStats.money = save.money;

            PlayerStats.spellsStats = save.spellsStats;

            Debug.Log("Game Loaded");
            return true;
        }
        else
        {
            Debug.Log("No game saved!");
            return false;
        }
    }
}
