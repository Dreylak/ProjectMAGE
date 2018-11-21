using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
