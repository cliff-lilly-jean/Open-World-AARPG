using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



[CreateAssetMenu(fileName = "InputReader", menuName = "New InputReader")]
public class InputReader : ScriptableObject, GameControls.IGameplayActions, GameControls.IUIActions
{

    private GameControls _gameControls;

    private void OnEnable()
    {
        if (_gameControls == null)
        {
            _gameControls = new GameControls();

            // Get the callbacks for the events on the game controls
            _gameControls.Gameplay.SetCallbacks(this);
            _gameControls.UI.SetCallbacks(this);

            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _gameControls.Gameplay.Enable();
        _gameControls.UI.Disable();
    }

    public void SetUI()
    {
        _gameControls.UI.Enable();
        _gameControls.Gameplay.Disable();
    }

    // Custom Events
    public event Action<Vector2> MoveEvent;

    public event Action JumpEvent;
    public event Action JumpCancelledEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    public void OnJump(InputAction.CallbackContext context)
    {
        // Default Implementation
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Default Implementation
        Debug.Log(context.phase);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        // Default Implementation
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        // Default Implementation
    }
}
