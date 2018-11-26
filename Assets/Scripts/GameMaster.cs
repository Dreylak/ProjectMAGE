using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

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

	public enum ElementTypes { Fire, Water, Earth, Air , Neutral};

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();

        PlayerStats.SavePlayerData();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        ResumeGame();
        PlayerStats.SetPlayerData();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
