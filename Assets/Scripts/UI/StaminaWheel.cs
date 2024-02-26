using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    public StaminaSO stamina;

    [SerializeField] private Image _greenWheel;
    [SerializeField] private Image _redWheel;


    // Update is called once per frame
    void Update()
    {
        if (stamina.movementSystem.move.isSprinting && !stamina._staminaExhausted)
        {
            if (stamina._stamina > 0)
            {
                _greenWheel.enabled = true;
                _redWheel.enabled = true;

                stamina._stamina -= 15 * Time.deltaTime;
            }
            else
            {
                _greenWheel.enabled = false;
                stamina._staminaExhausted = true;
                // TODO make a glow effect when stamina is exhausted
            }

            _redWheel.fillAmount = (stamina._stamina / stamina._maxStamina + (stamina._wheelFillSpeedOffset + .005f));
        }
        else
        {
            if (stamina._stamina < stamina._maxStamina)
            {
                stamina._stamina += 10 * Time.deltaTime;
            }
            else
            {
                stamina._staminaExhausted = false;

                // Hide wheels until isSprinting
                _greenWheel.enabled = false;
                _redWheel.enabled = false;
            }

            _redWheel.fillAmount = (stamina._stamina / stamina._maxStamina + (stamina._wheelFillSpeedOffset + .005f));
        }

        _greenWheel.fillAmount = (stamina._stamina / stamina._maxStamina);
    }
}


