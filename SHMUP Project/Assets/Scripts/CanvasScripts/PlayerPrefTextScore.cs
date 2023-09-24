using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefTextScore : MonoBehaviour
{
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score") + "";
    }
}
