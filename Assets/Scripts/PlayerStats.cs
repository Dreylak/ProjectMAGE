using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private static Dictionary<GameMaster.ElementTypes, int> Money;

    private void Start()
    {
        Money = new Dictionary<GameMaster.ElementTypes, int>
        {
            { GameMaster.ElementTypes.Air, 0 },
            { GameMaster.ElementTypes.Earth, 0 },
            { GameMaster.ElementTypes.Fire, 0 },
            { GameMaster.ElementTypes.Water, 0 },
            { GameMaster.ElementTypes.Neutral, 0}
        };

        //load player stats from save file
    }


    public static void AddMoney(GameMaster.ElementTypes moneyType, int moneyCount)
    {
        Money[moneyType] += moneyCount;
    }

    public static void SpendMoney(GameMaster.ElementTypes moneyType, int moneyCount)
    {
        Money[moneyType] -= moneyCount;
    }

    public static int GetMoneyCount(GameMaster.ElementTypes moneyType)
    {
        return Money[moneyType];
    }
}
