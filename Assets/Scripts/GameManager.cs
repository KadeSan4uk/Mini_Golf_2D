using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private BallController _ballController;
    [SerializeField] private ChargeLine _chargeLine;
    [SerializeField] private GameObject _canHit;
    [SerializeField] private float _lowSpeedThreshold = 1f;
    private int _currentScore = -15;
    private bool _ballInHole = false;
    private bool _isGameOver = false;
    

    private void Start()
    {
        UpdateScoreText();

        if(_chargeLine is not null)
            _chargeLine.gameObject.SetActive(true);
    }

    public void OnBallInHole(float ballSpeed)
    {
        if (ballSpeed <= _lowSpeedThreshold)
        {
            _ballInHole = true;
            _ballController.DisappearBall();
            ResetBallPosition();

            HideActionButton();
        }
    }

    public void OnBallStopped()
    {
        if (_ballInHole)
        {
            AddScore(true);
        }
        else
        {
            AddScore(false);
        }

        _ballInHole = false;

        ShowActionButton();
    }

    private void AddScore(bool isHoleHit)
    {
        if (isHoleHit)
        {
            _currentScore -= 5;
        }
        else
        {
            _currentScore += 5;
        }

        UpdateScoreText();

        if (_currentScore >= 0 && !_isGameOver)
        {
            Debug.Log("Вы проиграли! Очки закончились, но игра продолжается.");
            _isGameOver = true;
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_currentScore}";
    }

    public void ResetBallPosition()
    {
        _ballController.ResetBall(); 
    }
    private void ShowActionButton()
    {
        if (_canHit != null)
            _canHit.SetActive(true);
    }

    public void HideActionButton()
    {
        if (_canHit != null)
            _canHit.SetActive(false);
    }

}
