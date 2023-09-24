using UnityEngine;

public class PlayerRocketExplosion : MonoBehaviour
{
    public int damage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyTakeDamage>().TakeDamageByRocketExplosion();
            Destroy(gameObject, 1);
        }
    }
    
}