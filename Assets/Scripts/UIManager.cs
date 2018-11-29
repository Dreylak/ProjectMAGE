using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text moneyText;
    public Text castleHPText;
    public Text castleShieldText;

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        moneyText.text = PlayerStats.money.ToString();

        castleHPText.text = PlayerStats.castleMaxHP.ToString();
        castleShieldText.text = PlayerStats.castleMaxShield.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = PlayerStats.money.ToString();

        castleHPText.text = Castle.Instance.Health.ToString();
        castleShieldText.text = Castle.Instance.Shield.ToString();
    }

    public void ShowGameOverMenu()
    {
        gameObject.GetComponent<GameOverMenu>().ShowGameOverMenu();
    }
}
