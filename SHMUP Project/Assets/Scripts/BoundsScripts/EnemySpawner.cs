using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public Transform canvasTransfrom;

    public float spawnRate;
 
    private int _waves = 1;
      
    void Start()
    {
        spawnRate = 2;
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        WavesCounter();
    }

    private void SpawnEnemy()
    {
        if (_waves == 1)
        {
            GameObject newEnemy = Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length)], new Vector2(UnityEngine.Random.Range(-8.5f, 8.5f), 7), Quaternion.identity);
            EnemyShoot damage = newEnemy.GetComponent<EnemyShoot>();
            EnemyTakeDamage health = newEnemy.GetComponent<EnemyTakeDamage>();  
            if (damage != null)
            {
                damage.AddDamage(_waves);
                Debug.Log($"[New Enemies Damage] {damage.damage}");
            }
            health.AdditionalLife(_waves);
            Debug.Log($"[New Enemies HealthPoints] {health.health}");
        }
        if (_waves == 2)
        {          
            GameObject newEnemy = Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length)], new Vector2(UnityEngine.Random.Range(-8.5f, 8.5f), 7), Quaternion.identity);
            EnemyShoot damage = newEnemy.GetComponent<EnemyShoot>();
            EnemyTakeDamage health = newEnemy.GetComponent<EnemyTakeDamage>();
            if (damage != null)
            {            
                damage.AddDamage(_waves);
                Debug.Log($"[New Enemies Damage] {damage.damage}");
            }
            health.AdditionalLife(_waves);
            Debug.Log($"[New Enemies HealthPoints] {health.health}");
        }

        if (_waves == 3)
        {
            GameObject newEnemy = Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length)], new Vector2(UnityEngine.Random.Range(-8.5f, 8.5f), 7), Quaternion.identity);
            EnemyShoot damage = newEnemy.GetComponent<EnemyShoot>();
            EnemyTakeDamage health = newEnemy.GetComponent<EnemyTakeDamage>();
            if (damage != null)
            {

                damage.AddDamage(_waves);
                Debug.Log($"[New Enemies Damage] {damage.damage}");
            }
            health.AdditionalLife(_waves);
            Debug.Log($"[New Enemies HealthPoints] {health.health}");
        }

        if ((_waves == 4))
        {  
            GameObject newEnemy = Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length)], new Vector2(UnityEngine.Random.Range(-8.5f, 8.5f), 7), Quaternion.identity);
            EnemyShoot damage = newEnemy.GetComponent<EnemyShoot>();
            EnemyTakeDamage health = newEnemy.GetComponent<EnemyTakeDamage>();
            if (damage != null)
            {
                
                damage.AddDamage(_waves);
                Debug.Log($"[New Enemies Damage] {damage.damage}");
            }
            health.AdditionalLife(_waves);
            Debug.Log($"[New Enemies HealthPoints] {health.health}");
        }
    }

    public void WavesCounter()
    {
        if (PlayerPrefs.GetInt("Score") < 500)
        {
            PlayerPrefs.SetInt("Wave", _waves);
            _waves = 1;
        }
        if (PlayerPrefs.GetInt("Score") >= 500 && PlayerPrefs.GetInt("Score") < 1000)
        {
            PlayerPrefs.SetInt("Wave", _waves);           
            _waves = 2;
        }
        if (PlayerPrefs.GetInt("Score") >= 1000 && PlayerPrefs.GetInt("Score") < 1500)
        {
            PlayerPrefs.SetInt("Wave", _waves);
            _waves = 3;
        }
        if (PlayerPrefs.GetInt("Score") >= 1500)
        {
            PlayerPrefs.SetInt("Wave", _waves);
            _waves = 4;
        }
    }
}
