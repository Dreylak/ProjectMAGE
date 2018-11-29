using UnityEngine;
using Utilities;

public class PlayerStats : MonoBehaviour {

    public static int money;

    public static SpellStats[] spellsStats;

    public static int castleMaxHP = 100;
    public static int castleMaxShield = 100;
    public static float castleShieldRecovery = 1f;

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
}
