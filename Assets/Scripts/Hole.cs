using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            float ballSpeed = other.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
            _gameManager.OnBallInHole(ballSpeed);
        }
    }
}
