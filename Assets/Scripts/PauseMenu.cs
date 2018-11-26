using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;

    public void ShowPauseMenu()
    {
        GameMaster.Instance.PauseGame();
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameMaster.Instance.ResumeGame();
    }

    private void Update()
    {
        if (!pauseMenuUI.activeInHierarchy) return;
        
        if(Input.GetMouseButtonDown(0))
        {
            //TODO: timer
            Resume();
        }
    }
}
