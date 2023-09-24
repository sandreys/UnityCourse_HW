using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _body;

    private int _direction = -1;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        _body.velocity = new Vector2(0, 5 * _direction);
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage();
            Destroy(gameObject);
        }
    }
}
