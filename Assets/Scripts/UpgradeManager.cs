using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class UpgradeManager : MonoBehaviour {

    public SpellUpgradeUI[] spellsUpgradeUI;
    public CastleUpgradeUI castleUpgradeUI;
    public int maxUpgradesCount = 4;

    public static UpgradeManager Instance { get; private set; }

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

    public void ShowUpgrades()
    {
        for(int i = 0; i < spellsUpgradeUI.Length; i++)
        {
            int upgradesBought = PlayerStats.upgradesStatus.spellsDamageUpgradesBought[spellsUpgradeUI[i].type];
            Debug.Log(upgradesBought);
            for (int j = 0; j < upgradesBought; j++)
            {
                Transform boughtItem = spellsUpgradeUI[i].damageUpgradeUI.transform.GetChild(j);
                boughtItem.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    public void UpgradeSpellDamage(Spell spell)
    {
        int upgradeNum = PlayerStats.upgradesStatus.spellsDamageUpgradesBought[spell.damageType];
        
        //check if all upgrades are bought
        if (upgradeNum >= maxUpgradesCount)
        {
            Debug.Log("All upgrades are bought");
            return;
        }

        int upgradeCost = GetDamageUpgradeCost(upgradeNum);
        
        //check if enough money
        if (PlayerStats.money < upgradeCost)
        {
            Debug.Log("Not enough money. Your money: " + PlayerStats.money);
            return;
        }

        //decrease money for upgrade cost
        PlayerStats.money -= upgradeCost;
        //increase spell damage
        PlayerStats.spellsStats[spell.damageType].damage += GetDamageUpgradeIncrease();

        //visualise upgrade
        for (int i = 0; i < spellsUpgradeUI.Length; i++)
        {
            if (spellsUpgradeUI[i].type == spell.damageType)
            {
                Transform newUpgradeItem = spellsUpgradeUI[i].damageUpgradeUI.transform.GetChild(upgradeNum);
                newUpgradeItem.GetComponent<Toggle>().isOn = true;
            }
        }

        //increase upgrades count
        PlayerStats.upgradesStatus.spellsDamageUpgradesBought[spell.damageType]++;
    }

    private int GetDamageUpgradeCost(int upgradeNum)
    {
        //return 0;
        return upgradeNum * 10;
    }

    private int GetDamageUpgradeIncrease()
    {
        return 10;
    }
}
