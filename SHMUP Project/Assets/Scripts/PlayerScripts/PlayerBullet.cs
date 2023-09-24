using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    bullet,
    rocket
}
public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D _body;

    public AmmoType type;

    public GameObject explosion;

    public int direction = 1;
    public int damage;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        
    }
 
    void Update()
    {
        _body.velocity = new Vector2(0, 5 * direction);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (type == AmmoType.bullet)
            {
                collision.gameObject.GetComponent<EnemyTakeDamage>().TakeDamageByBullet();
                Destroy(gameObject);
            }

            if (type == AmmoType.rocket)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
