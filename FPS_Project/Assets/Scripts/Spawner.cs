using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject[] Spawners;


    public GameObject Enemy;
    public GameObject Player;

    

    

    public void Start()
    {
        instance = this;
        for (int i = 0; i < PlayerPrefs.GetInt("Bots"); i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {

        GameObject newEnemy = Instantiate(Enemy, Spawners[Random.Range(0, Spawners.Length - 1)].transform.position, Quaternion.identity);

    }

    public void SpawnPlayer()
    {
        CharacterController characterController = Player.GetComponent<CharacterController>();

        Vector3 newPosition = Spawners[Random.Range(0, Spawners.Length)].transform.position;
        characterController.enabled = false;
        Player.transform.position = newPosition;
        characterController.enabled = true;
        


    }

    public IEnumerator SpawnEnemyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnEnemy();
    }

}
