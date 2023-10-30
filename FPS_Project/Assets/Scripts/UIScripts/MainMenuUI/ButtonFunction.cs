using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

    public string[] Maps = new string[] { "Dust" };
    public GameObject gameSettings;
    public TextMeshProUGUI mapText;
    public TextMeshProUGUI botsText;

    private int _currentIndex = 0;
    private int _botCounter = 1;
    private int _maxBotCounter = 5;
    public void Awake()
    {
        mapText.text = Maps[0];
        botsText.text = _botCounter.ToString();
        PlayerPrefs.SetInt("Bots", _botCounter);
    }

    public void OpenGameSettings()
    {
        gameSettings.transform.localScale = Vector3.one;
    }

    public void NextMap()
    {
        if (_currentIndex < Maps.Length - 1)
        {
            _currentIndex++;
            mapText.text = Maps[_currentIndex];

        }
        else
        {
            _currentIndex = 0;
            mapText.text = Maps[_currentIndex];
        }


    }

    public void AddBot()
    {
        if (_botCounter < _maxBotCounter)
        {
            _botCounter++;
        }
        else
        {
            _botCounter = 1;
        }
        botsText.text = _botCounter.ToString();
        PlayerPrefs.SetInt("Bots", _botCounter);
    }

    public void DeleteBot()
    {
        if (_botCounter > 1)
        {
            _botCounter--;
        }
        else
        {
            _botCounter = _maxBotCounter;
        }
        botsText.text = _botCounter.ToString();
        PlayerPrefs.SetInt("Bots", _botCounter);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    
public void Quit()
    {
        EditorApplication.ExitPlaymode();
    }
}

