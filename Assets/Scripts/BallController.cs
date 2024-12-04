using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _movementSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up*_movementSpeed, ForceMode2D.Impulse);
        }
    }
}
