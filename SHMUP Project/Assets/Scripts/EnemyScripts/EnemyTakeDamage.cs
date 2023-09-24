using System.Collections;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] public int _deathScore;

    public GameObject[] gunsPrefabs;

    public GameObject explosion;
    public GameObject healthPointDrop;
    public GameObject invulnarableBuffDrop;

    public PlayerBullet bullet;
    public PlayerRocketExplosion rocketExplosion;

    public int gunDropNumber;
    public int health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage();
            Die();
        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamageByBullet()
    {
        StartCoroutine(Blink());
        health -= bullet.damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamageByRocketExplosion()
    {
        StartCoroutine(Blink());
        health -= rocketExplosion.damage;
        Debug.Log($"{rocketExplosion.damage}");
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DropGun();

        if (Random.Range(0, 10) <= 6)
        {
            Instantiate(healthPointDrop, transform.position, Quaternion.identity);
        }else
        {
            Instantiate(invulnarableBuffDrop, transform.position, Quaternion.identity);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);       
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + _deathScore);
        Destroy(gameObject);
    }

    public void DropGun()
    {
        gunDropNumber = Random.Range(0, 40);
        if (gunDropNumber <= 5)
        {
            Instantiate(gunsPrefabs[0], transform.position, Quaternion.identity);
        }
        if (gunDropNumber <= 10 && gunDropNumber > 5)
        {
            Instantiate(gunsPrefabs[1], transform.position, Quaternion.identity);
        }
        if (gunDropNumber <= 15 && gunDropNumber > 10)
        {
            Instantiate(gunsPrefabs[2], transform.position, Quaternion.identity);
        }
        if (gunDropNumber > 20)
        {
            Instantiate(gunsPrefabs[3], transform.position, Quaternion.identity);
        }
    }

    public void AdditionalLife(int wave)
    {
        if (wave == 1)
        {
            health = 2;
        }
        if (wave == 2)
        {
            health = 4;
        }
        if (wave == 3)
        {
            health = 6;
        }

        if (wave == 4)
        {
            health = 8;
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
