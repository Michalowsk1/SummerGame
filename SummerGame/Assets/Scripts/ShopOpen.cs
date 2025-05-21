using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] GameObject upgrades;
    [SerializeField] GameObject abilities;

    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopIcon;

    public static bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        ShopIcon.SetActive(true);
        upgrades.SetActive(true);
        abilities.SetActive(false);
        Shop.SetActive(false);
    }

    public void OpenShop()
    {
        Shop.SetActive(true);
        ShopIcon.SetActive(false);
        Time.timeScale = 0.0f;
        open = true;
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        ShopIcon.SetActive(true);
        Time.timeScale = 1.0f;
        open = false;
    }


    public void OpenUpgrades()
    {
        upgrades.SetActive(true);
        abilities.SetActive(false);
    }

    public void OpenAbilities()
    {
        upgrades.SetActive(false);
        abilities.SetActive(true);
    }
}
