using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        EditorApplication.ExitPlaymode();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenInventort()
    {
        Debug.Log($"[Inventory.Instance.isOpened)] {Inventory.Instance.isOpened}");

            if (Inventory.Instance.isOpened)
            {
                Inventory.Instance.Close();
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
                Inventory.Instance.Open();
            }
        
    }
}
