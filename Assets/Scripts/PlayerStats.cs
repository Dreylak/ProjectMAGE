using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private static int money;
    public static int Money
    {
        get
        {
            return money;
        }
    }

    private static int castleMaxHP = 100;
    public static int CastleMaxHP
    {
        get
        {
            return castleMaxHP;
        }
    }

    private static int castleMaxShield = 100;
    public static int CastleMaxShield
    {
        get
        {
            return castleMaxShield;
        }
    }

    private void Awake()
    {
        LoadPlayerData();
        SetPlayerData();
    }

    //TODO: update this function
    //set saved player stats to game
    public static void SetPlayerData()
    {
        Castle.Instance.maxHealth = castleMaxHP;
        Castle.Instance.maxShield = castleMaxShield;
    }

    public static void AddMoney(int moneyCount)
    {
        money += moneyCount;
    }

    public static void SpendMoney(int moneyCount)
    {
        if (money >= moneyCount)
            money -= moneyCount;
        else
            Debug.Log("Not enough money!");
    }

    //TODO : load player stats from save-file
    public static void LoadPlayerData()
    {

    }

    //TODO : save player stats to save-file
    public static void SavePlayerData()
    {

    }
}
