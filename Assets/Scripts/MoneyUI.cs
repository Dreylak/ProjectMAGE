using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Maybe this class shoudnt exist
 * Its possible to update money UI in player stats where money value are changed
 */
public class MoneyUI : MonoBehaviour {

    public Text[] moneyTexts;

    void Start()
    {
        for (int i = 0; i < moneyTexts.Length; i++)
        {
            int moneyCount = PlayerStats.GetMoneyCount((GameMaster.ElementTypes)i);
            moneyTexts[i].text = moneyCount.ToString();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < moneyTexts.Length; i++)
        {
            int moneyCount = PlayerStats.GetMoneyCount((GameMaster.ElementTypes)i);
            moneyTexts[i].text = moneyCount.ToString();
        }
    }
}
