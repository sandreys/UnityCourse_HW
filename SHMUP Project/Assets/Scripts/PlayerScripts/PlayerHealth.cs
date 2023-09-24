using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public Slider healthBar;

    public bool isInvulnerable = false;
    public float invulnerabilityDuration = 4f;
    public float invulnerabilityTimer = 0f;

    public GameObject explosion;
    public void Start()
    {
        healthBar.maxValue = _maxHealth;
        healthBar.value = _maxHealth;
    }
    void Update()
    {
        InvulnerableStatus();
        SetHealth(_currentHealth);
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    public void Damage()
    {
        if (!isInvulnerable)
        {
            _currentHealth -= EnemyShoot.Instance.damage;
            StartCoroutine(Blink());
            Debug.Log($"Health: {_currentHealth}");

            if (_currentHealth <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject, 0.1f);
            }
        }
    }

    public void AddHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth++;
        }
        else
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 50);
        }
    }

    public void GiveInvulnerable()
    {
        Debug.Log($"[GiveInvulnerable] Неуязвим");
        StartCoroutine(Invulnerable());

        isInvulnerable = true;
        invulnerabilityTimer = 0f;
    }

    public void InvulnerableStatus()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer += Time.deltaTime;
            if (invulnerabilityTimer >= invulnerabilityDuration)
            {
                Debug.Log($"[GiveInvulnerable] Уязвим");
                isInvulnerable = false;
            }
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    IEnumerator Invulnerable()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(invulnerabilityDuration);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }



}
