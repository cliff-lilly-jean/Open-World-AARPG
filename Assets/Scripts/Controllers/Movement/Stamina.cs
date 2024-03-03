using UnityEngine;

public class Stamina : MonoBehaviour
{
    MovementSystem MovementSystem;
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {

    }


}