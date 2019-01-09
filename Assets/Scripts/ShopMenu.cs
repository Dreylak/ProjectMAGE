using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class ShopMenu : MonoBehaviour {

    public GameObject shopMenu;

    public void ShowShopMenu()
    {
        GameMaster.Instance.PauseGame();
        shopMenu.SetActive(true);
        UpgradeManager.Instance.ShowUpgrades();
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
       
        GameMaster.Instance.RestartGame();
    }
}
