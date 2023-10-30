using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    public int weaponIndicator = 0;
    public GameObject[] weapons = new GameObject[2];
    private UIManager UIManager;

    public void Start()
    {
        UIManager = FindAnyObjectByType<UIManager>();

        SwitchWeapon(0);
    }
    public void SwitchWeapon(int index)
    { 
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        UIManager.SetWeaponToDisplay(index);

        weapons[index].SetActive(true);
        weaponIndicator = index;

    }
}
