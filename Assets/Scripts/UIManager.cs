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
        moneyText.text = PlayerStats.Money.ToString();

        castleHPText.text = PlayerStats.CastleMaxHP.ToString();
        castleShieldText.text = PlayerStats.CastleMaxShield.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = PlayerStats.Money.ToString();

        castleHPText.text = Castle.Instance.Health.ToString();
        castleShieldText.text = Castle.Instance.Shield.ToString();
    }

    public void ShowGameOver()
    {
        gameObject.GetComponent<GameOverMenu>().ShowGameOverMenu();
    }
}
