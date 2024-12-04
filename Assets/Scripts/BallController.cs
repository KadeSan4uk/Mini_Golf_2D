using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 newPosition = _rb.position + Vector2.up * Time.deltaTime * _movementSpeed;
            _rb.MovePosition(newPosition);
        }
    }
}
