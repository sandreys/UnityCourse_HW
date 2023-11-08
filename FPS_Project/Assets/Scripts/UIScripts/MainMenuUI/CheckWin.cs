using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public Transform RedTeam;
    public Transform BlueTeam;
    public void Awake()
    {
        if (PlayerPrefs.GetInt("RedScore") >= 1000)
        {
            RedTeam.transform.localScale = Vector3.one;
        }
        else
        {
            BlueTeam.transform.localScale = Vector3.one;
        }
    }
}
