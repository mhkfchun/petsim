using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonActionTester : MonoBehaviour
{
    public InputActionAsset actionAsset; // Reference to your Input Actions asset
    private InputAction xButtonAction;   // The specific action for the X button
    public GameObject spawnObject;  

    private void OnEnable()
    {
        // Specify the named action map and the action
        xButtonAction = actionAsset.FindActionMap("MyActionMap").FindAction("MyActionPress");
        xButtonAction.performed += OnXButtonPressed;
        xButtonAction.Enable();
    }
    private void OnDisable()
    {
        xButtonAction.Disable();
    }

    // When the event is detected, spawn an object
    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        Instantiate(spawnObject);
    }
}
