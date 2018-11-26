using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour {

    public GameObject shopMenu;
    public GameObject[] shopPagesUI;
    private GameObject activePage = null;

    public void ShowShopMenu()
    {
        GameMaster.Instance.PauseGame();
        shopMenu.SetActive(true);
        OpenPage(0);
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
       
        GameMaster.Instance.RestartGame();
    }

    public void OpenPage(int i)
    {
        CloseActivePage();
        shopPagesUI[i].SetActive(true);
        activePage = shopPagesUI[i];
    }

    public void CloseActivePage()
    {
        if (activePage == null) return;

        activePage.SetActive(false);
    }
}
