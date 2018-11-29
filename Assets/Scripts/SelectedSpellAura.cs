using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SelectedSpellAura : MonoBehaviour {

    public Color fireColor;
    public Color waterColor;
    public Color earthColor;
    public Color airColor;

    void Update ()
    {
        ElementTypes spellType = Mage.Instance.SelectedSpell.GetComponent<Spell>().damageType;

        switch (spellType)
        {
            case (ElementTypes.Fire):
                {
                    gameObject.GetComponent<SpriteRenderer>().color = fireColor;
                    break;
                }

            case (ElementTypes.Water):
                {
                    gameObject.GetComponent<SpriteRenderer>().color = waterColor;
                    break;
                }
            case (ElementTypes.Earth):
                {
                    gameObject.GetComponent<SpriteRenderer>().color = earthColor;
                    break;
                }
            case (ElementTypes.Air):
                {
                    gameObject.GetComponent<SpriteRenderer>().color = airColor;
                    break;
                }
        }
    }
}
