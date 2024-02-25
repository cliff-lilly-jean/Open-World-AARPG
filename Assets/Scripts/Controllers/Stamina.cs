using UnityEngine;

public class Stamina : MonoBehaviour
{
    public StaminaSO stamina;
    public MovementSystemSO movementSystem;

    // Start is called before the first frame update
    void Start()
    {
        stamina.stamina = stamina.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementSystem.move.isSprinting)
        {
            DecreaseStamina();
        }
        else if (stamina.stamina < stamina.maxStamina)
        {
            IncreaseStamina();
        }
    }

    public void DecreaseStamina()
    {
        Debug.Log("Depleate stamina");

        stamina.stamina -= 10 * Time.deltaTime;

        Debug.Log(stamina.stamina);
    }

    public void IncreaseStamina()
    {
        Debug.Log("Increase stamina");
        stamina.stamina += 10 * Time.deltaTime;
    }
}
