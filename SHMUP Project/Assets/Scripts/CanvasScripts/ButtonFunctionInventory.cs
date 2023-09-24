using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionInventory : MonoBehaviour
{ 
      public void OpenInventory()
    {
        Debug.Log($"[Inventory.Instance.isOpened)] {Inventory.Instance.isOpened}");
        if (Inventory.Instance.isOpened)
        {
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
}
