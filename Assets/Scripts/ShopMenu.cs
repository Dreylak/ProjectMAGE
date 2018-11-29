using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour {

    public GameObject shopMenu;

    public void ShowShopMenu()
    {
        GameMaster.Instance.PauseGame();
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
       
        GameMaster.Instance.RestartGame();
    }
}
