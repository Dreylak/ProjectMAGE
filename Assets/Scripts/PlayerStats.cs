using UnityEngine;
using System.Collections.Generic;
using Utilities;

public class PlayerStats : MonoBehaviour {

    //TODO: mb delete Save class and save the PlayerStats 
    //(delete monoBeh and make it serializable)
    //TODO: mb make this class singleton to be able to set default params in inspector
    //should I do it?




    public static int money;

    public static Dictionary<ElementTypes, SpellStats> spellsStats;

    public static int castleMaxHP;
    public static int castleMaxShield;
    public static float castleShieldRecovery;

    public static UpgradesStatus upgradesStatus;

    public static void SetToDefault()
    {
        money = 0;

        castleMaxHP = GameMaster.Instance.castle.maxHealth;
        castleMaxShield = GameMaster.Instance.castle.maxShield;
        castleShieldRecovery = GameMaster.Instance.castle.shieldRecovery;

        int spellsCount = GameMaster.Instance.spells.Length;

        spellsStats = new Dictionary<ElementTypes, SpellStats>(spellsCount);
        for (int i = 0; i < spellsCount; i++)
        {
            spellsStats.Add(GameMaster.Instance.spells[i].damageType, 
                            new SpellStats(GameMaster.Instance.spells[i]));
        }

        upgradesStatus = new UpgradesStatus();
        upgradesStatus.castleMaxShieldUpgradesBought = 0;
        upgradesStatus.castleShieldRecoveryCostUpgradesBought = 0;

        upgradesStatus.spellsCooldownUpgradesBought = new Dictionary<ElementTypes, int>();
        upgradesStatus.spellsDamageUpgradesBought = new Dictionary<ElementTypes, int>();
        upgradesStatus.spellsSpeedUpgradesBought = new Dictionary<ElementTypes, int>();

        for (ElementTypes i = ElementTypes.Fire; i <= ElementTypes.Air; i++)
        {
            Debug.Log(i);
            upgradesStatus.spellsCooldownUpgradesBought.Add(i, 0);
            upgradesStatus.spellsDamageUpgradesBought.Add(i, 0);
            upgradesStatus.spellsSpeedUpgradesBought.Add(i, 0);
        }
    }
}
