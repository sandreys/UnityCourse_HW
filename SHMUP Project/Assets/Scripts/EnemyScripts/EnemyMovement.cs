using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D _body;

    public int xSpeed;
    public int ySpeed;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _body.velocity = new Vector2(xSpeed, ySpeed);
    }
}
