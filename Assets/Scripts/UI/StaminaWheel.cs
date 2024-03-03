using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    public Endurance endurance;
    MovementSystem movementSystem;

    [SerializeField] private Image _greenWheel;
    [SerializeField] private Image _redWheel;


    // Update is called once per frame
    void Update()
    {
        if (movementSystem.sprint.isRunning && !endurance._staminaExhausted)
        {
            if (endurance._stamina > 0)
            {
                _greenWheel.enabled = true;
                _redWheel.enabled = true;

                endurance._stamina -= 15 * Time.deltaTime;
            }
            else
            {
                _greenWheel.enabled = false;
                endurance._staminaExhausted = true;
                // TODO make a glow effect when endurance is exhausted
            }

            _redWheel.fillAmount = (endurance._stamina / endurance._maxStamina + (endurance._wheelFillSpeedOffset + .005f));
        }
        else
        {
            if (endurance._stamina < endurance._maxStamina)
            {
                endurance._stamina += 10 * Time.deltaTime;
            }
            else
            {
                endurance._staminaExhausted = false;

                // Hide wheels until isRunning
                _greenWheel.enabled = false;
                _redWheel.enabled = false;
            }

            _redWheel.fillAmount = (endurance._stamina / endurance._maxStamina + (endurance._wheelFillSpeedOffset + .005f));
        }

        _greenWheel.fillAmount = (endurance._stamina / endurance._maxStamina);
    }
}


