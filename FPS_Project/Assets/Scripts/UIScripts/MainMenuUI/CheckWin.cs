using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public Transform redTeam;
    public Transform blueTeam;
    public void Awake()
    {
        if (PlayerPrefs.GetInt("RedScore") >= 1000)
        {
            redTeam.transform.localScale = Vector3.one;
        }
        else
        {
            blueTeam.transform.localScale = Vector3.one;
        }
    }
}
