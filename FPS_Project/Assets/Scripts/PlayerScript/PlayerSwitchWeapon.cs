using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    public int WeaponIndicator = 0;
    public GameObject[] Weapons = new GameObject[2];
    private UIManager _uiManager;

    public void Start()
    {
        _uiManager = FindAnyObjectByType<UIManager>();

        SwitchWeapon(0);
    }
    public void SwitchWeapon(int index)
    { 
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }
        _uiManager.SetWeaponToDisplay(index);

        Weapons[index].SetActive(true);
        WeaponIndicator = index;

    }
}
