using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PrimaryWeapon;
    public GameObject SecondaryWeapon;

    public void SetWeaponToDisplay(int index)
    {
        if (index == 0)
        {
            PrimaryWeapon.SetActive(false);
            SecondaryWeapon.SetActive(true);
        }
        else
        {
            PrimaryWeapon.SetActive(true);
            SecondaryWeapon.SetActive(false);
        }
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
    }
    public void ActivateUI()
    {
        gameObject.SetActive(true);
    }

}
