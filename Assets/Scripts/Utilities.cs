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

        public SpellStats(Spell spell)
        {
            speed = spell.speed;
            cooldown = spell.cooldown;
            damage = spell.damage;
        }
    }

    [System.Serializable]
    public class Save
    {
        public int money;

        public Dictionary<ElementTypes, SpellStats> spellsStats;

        public int castleMaxHP;
        public int castleMaxShield;
        public float castleShieldRecovery;

        public UpgradesStatus upgradesStatus;
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
        public int castleMaxShieldUpgradesBought;
        public int castleShieldRecoveryCostUpgradesBought;

        public Dictionary<ElementTypes, int> spellsSpeedUpgradesBought;
        public Dictionary<ElementTypes, int> spellsDamageUpgradesBought;
        public Dictionary<ElementTypes, int> spellsCooldownUpgradesBought;
    }

    [System.Serializable]
    public class SpellUpgradeUI
    {
        public ElementTypes type;
        public GameObject damageUpgradeUI;
        public GameObject speedUpgradeUI;
        public GameObject cooldownUpgradeUI;
    }

    [System.Serializable]
    public class CastleUpgradeUI
    {
        public GameObject maxShieldUpgradeUI;
        public GameObject shiedRecoveryUpgradeUI;
    }
}
