using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefTextWave : MonoBehaviour
{
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Wave") + "";
    }
}
