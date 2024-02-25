using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    StaminaSO stamina;

    [SerializeField] private Image _greenWheel;
    [SerializeField] private Image _redWheel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _greenWheel.fillAmount = (stamina.stamina / stamina.maxStamina);
    }
}
