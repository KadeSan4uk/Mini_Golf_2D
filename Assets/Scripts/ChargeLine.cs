using UnityEngine;

public class ChargeLine : MonoBehaviour
{
    [SerializeField] private BallController _ballController;
    [SerializeField] private GameObject _startCharge;
    [SerializeField] private GameObject _middleCharge;
    [SerializeField] private GameObject _endCharge;   

    private void Update()
    {
        if (_ballController.IsCharging())
        {
            float chargeLevel = _ballController.GetChargeLevel();

            _startCharge.SetActive(chargeLevel > 0f);
            _middleCharge.SetActive(chargeLevel > 0.33f);
            _endCharge.SetActive(chargeLevel > 0.66f);
        }
        else
        {
            _startCharge.SetActive(false);
            _middleCharge.SetActive(false);
            _endCharge.SetActive(false);
        }
    }
}
