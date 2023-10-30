using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueTeamScoreUpdate : MonoBehaviour
{
    public int _scoreForWin = 1000;
    public void Start()
    {
        PlayerPrefs.SetInt("BlueScore", 0);
    }
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("BlueScore") + "";
        if (PlayerPrefs.GetInt("BludScore") >= _scoreForWin)
        {
            SceneManager.LoadScene(2);
        }
    }
}
