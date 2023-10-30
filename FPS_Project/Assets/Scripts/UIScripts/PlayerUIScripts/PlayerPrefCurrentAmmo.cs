using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefCurrentAmmo : MonoBehaviour
{
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("CurrentAmmo") + "";
    }
}
