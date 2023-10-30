using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;

    public void SetWeaponToDisplay(int index)
    {
        if (index == 0)
        {
            primaryWeapon.SetActive(false);
            secondaryWeapon.SetActive(true);
        }
        else
        {
            primaryWeapon.SetActive(true);
            secondaryWeapon.SetActive(false);
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
