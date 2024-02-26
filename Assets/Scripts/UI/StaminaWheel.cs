using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    public MovementSystemSO movementSystem;

    private float _stamina;
    private float _maxStamina = 100f;

    [SerializeField] private float _wheelFillSpeedOffset;

    [SerializeField] private Image _greenWheel;
    [SerializeField] private Image _redWheel;

    private bool _staminaExhausted;



    // Start is called before the first frame update
    void Start()
    {
        _stamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementSystem.move.isSprinting && !_staminaExhausted)
        {
            if (_stamina > 0)
            {
                _greenWheel.enabled = true;
                _redWheel.enabled = true;

                _stamina -= 15 * Time.deltaTime;
            }
            else
            {
                _greenWheel.enabled = false;
                _staminaExhausted = true;
                // TODO make a glow effect when stamina is exhausted
            }

            _redWheel.fillAmount = (_stamina / _maxStamina + (_wheelFillSpeedOffset + .005f));
        }
        else
        {
            if (_stamina < _maxStamina)
            {
                _stamina += 10 * Time.deltaTime;
            }
            else
            {
                _staminaExhausted = false;

                // Hide wheels until isSprinting
                _greenWheel.enabled = false;
                _redWheel.enabled = false;
            }

            _redWheel.fillAmount = (_stamina / _maxStamina + (_wheelFillSpeedOffset + .005f));
        }

        _greenWheel.fillAmount = (_stamina / _maxStamina);
    }
}


