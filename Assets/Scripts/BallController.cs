using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private float _movementSpeed = 30f;
    [SerializeField] private float _chargeTime = 2f;
    [SerializeField] private float _stopThreshold = 0.1f;
    private Vector3 _startPosition;

    private bool _isCharging = false;
    private float _chargeTimer = 0f;
    private bool _isMoving = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (!_isMoving && Input.GetKey(KeyCode.Space))
        {
            _isCharging = true;
            _chargeTimer += Time.deltaTime;
            _chargeTimer = Mathf.Clamp(_chargeTimer, 0f, _chargeTime);
        }

        if (_isCharging && Input.GetKeyUp(KeyCode.Space))
        {
            float chargeRatio = _chargeTimer / _chargeTime;
            float force = chargeRatio * _movementSpeed;
            _rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

            _isCharging = false;
            _chargeTimer = 0f;
            _isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving && _rb.linearVelocity.magnitude <= _stopThreshold)
        {
            _isMoving = false;
            _gameManager.OnBallStopped();
        }
    }
    public void DisappearBall()
    {
        gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        _rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(true);
        _isMoving = false;
    }
}
