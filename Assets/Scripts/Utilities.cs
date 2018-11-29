using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public enum ElementTypes { Fire, Water, Earth, Air, Neutral };

    [System.Serializable]
    public class SpellStats
    {
        public float speed = 1f;
        public float cooldown = 1f;
        public int damage = 50;
    }

    [System.Serializable]
    public class Save
    {
        public int money;

        public SpellStats[] spellsStats;

        public int castleMaxHP;
        public int castleMaxShield;
        public float castleShieldRecovery;
    }

    [System.Serializable]
    public class Resist
    {
        public ElementTypes resistType;
        public float resistCount = 0f;
    }

    [System.Serializable]
    public class UpgradesStatus
    {
        public int castleMaxShieldCost;
        public int castleShieldRecoveryCost;

        public int castleMaxShieldUpgradesBought;
        public int castleShieldRecoveryCostUpgradesBought;

        public int[] spellsSpeedUpgradeCost;
        public int[] spellsDamageUpgradeCost;
        public int[] spellsCooldownUpgradeCost;

        public int[] spellsSpeedUpgradesBought;
        public int[] spellsDamageUpgradesBought;
        public int[] spellsCooldownUpgradesBought;
    }

}
