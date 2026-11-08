
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputAction shootAction, restartAction;

    // Start is called before the first frame update
    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Player/Shoot");
        restartAction = InputSystem.actions.FindAction("Player/Restart");
    }

    // Update is called once per frame
    void Update()
    {
        if (restartAction.IsPressed())
            GameEvents.TriggerRestart();

        if (shootAction.IsPressed())
            GameEvents.TriggerStartCharging();

        if (shootAction.WasReleasedThisFrame())
            GameEvents.TriggerShoot();
    }
}
