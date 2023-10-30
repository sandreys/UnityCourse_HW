using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float _health;
    [SerializeField] private float _lerpTimer;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float chipSpeed = 2f;

    public SkinnedMeshRenderer[] playerSkin;
    public Image frontHealthBar;
    public Image backHealthBar;

    public Spawner playerSpawner;
    public Camera MainCamera;
    public Camera DeathCamera;

    public UIManager Ui;
    public Ragdoll _ragdoll;

    private int _deathPoints = 200;
    private bool _isDead;
    private float _respawnDelay = 3f;
    public void Start()
    {
        _health = _maxHealth;

    }

    public void Update()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {

        float fillFrontBar = frontHealthBar.fillAmount;
        float fillBackBar = backHealthBar.fillAmount;
        float healthFraction = _health / _maxHealth;
        if (fillBackBar > healthFraction)
        {

            frontHealthBar.fillAmount = healthFraction;
            backHealthBar.color = Color.red;
            _lerpTimer += Time.deltaTime;

            float percentComplete = _lerpTimer / chipSpeed;

            backHealthBar.fillAmount = Mathf.Lerp(fillBackBar, healthFraction, percentComplete);

        }

        if (fillFrontBar < healthFraction)
        {

            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = healthFraction;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillFrontBar, backHealthBar.fillAmount, percentComplete);
        }

    }


    public void TakeDamage(float damage)
    {
        if (!_isDead)
        {
            _health -= damage;
            _lerpTimer = 0f;

            if (_health <= 0f)
            {
                _isDead = true;
                Die();
            }
        }

    }

    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _lerpTimer = 0f;
    }
    public void Die()
    {
        _ragdoll.ActivateRagdoll();
        ChangeToDeathCamera();
        Ui.DisableUI();
        for (int i = 0; i < playerSkin.Length; i++)
        {
            playerSkin[i].enabled = true;
        }
        PlayerPrefs.SetInt("BlueScore", PlayerPrefs.GetInt("BlueScore") + _deathPoints);
        StartCoroutine(RespawnDelay(_respawnDelay));

    }

    private IEnumerator RespawnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < playerSkin.Length; i++)
        {
            playerSkin[i].enabled = false;
        }
        _isDead = false;
        _ragdoll.DeactivateRagdoll();
        ChangeToMainCamera();
        Ui.ActivateUI();
        _health = _maxHealth;
        playerSpawner.SpawnPlayer();

    }

    public void ChangeToDeathCamera()
    {

        MainCamera.gameObject.SetActive(false);
        DeathCamera.gameObject.SetActive(true);
    }
    public void ChangeToMainCamera()
    {
        MainCamera.gameObject.SetActive(true);
        DeathCamera.gameObject.SetActive(false);
    }
}