using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedTeamScoreUpdate : MonoBehaviour
{
    private int _scoreForWin = 1000;
    public void Awake()
    {
        PlayerPrefs.SetInt("RedScore", 0);
    }
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("RedScore") + "";
        if (PlayerPrefs.GetInt("RedScore") >= _scoreForWin)
        {
            SceneManager.LoadScene(2);
        }
    }
}
