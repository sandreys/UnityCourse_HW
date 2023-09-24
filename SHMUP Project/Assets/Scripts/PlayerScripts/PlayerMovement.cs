using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.deltaTime != 0f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Movement(Vector2.up);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Movement(Vector2.down);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Movement(Vector2.right);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Movement(Vector2.left);
            }
        }  
    }

    private void Movement(Vector2 direction)
    {
        _body.AddForce(direction * _speed);
    }
}
