using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    public GameObject gameOverUI;

    public void ShowGameOverMenu()
    {
        GameMaster.Instance.PauseGame();
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        gameOverUI.SetActive(false);
        GameMaster.Instance.RestartGame();
    }
}
