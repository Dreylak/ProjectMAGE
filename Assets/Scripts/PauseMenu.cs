using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject timerText;
    public GameObject pausedText;

    public float timeBeforeResume = 3.0f;

    public void ShowPauseMenu()
    {
        GameMaster.Instance.PauseGame();
        pauseMenuUI.SetActive(true);

        timerText.SetActive(false);
        pausedText.SetActive(true);
    }

    public void Resume()
    {
        pausedText.SetActive(false);
        timerText.SetActive(true);

        //TODO: timer
        //CancelInvoke("Finished");
        //Invoke("Finished", timeBeforeResume);

        pauseMenuUI.SetActive(false);
        GameMaster.Instance.ResumeGame();
    }

    public void Finished()
    {
        pauseMenuUI.SetActive(false);
        GameMaster.Instance.ResumeGame();
    }
}
