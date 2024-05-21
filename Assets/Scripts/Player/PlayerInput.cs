using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputActions input;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    private void Awake()
    {
        input = new InputActions();
    }

    // Update is called once per frame
    void Update()
    {
        #region Standard Movements
        input.Player.Horizontal.started += Horizontal;
        input.Player.Horizontal.performed += Horizontal;
        input.Player.Horizontal.canceled += Horizontal;

        input.Player.Vertical.started += Vertical;
        input.Player.Vertical.performed += Vertical;
        input.Player.Vertical.canceled += Vertical;
        #endregion

        #region Camera Controls
        input.Player.MouseX
        #endregion
    }

    #region 'Get' Functions

    public float GetHorizontalInput() { return horizontalInput; }
    public float GetVerticalInput() { return verticalInput; }

    #endregion

    #region Standard Movement Functions

    void Horizontal(InputAction.CallbackContext c)
    {
        horizontalInput = c.ReadValue<float>();
    }

    void Vertical(InputAction.CallbackContext c)
    {
        verticalInput = c.ReadValue<float>();
    }

    #endregion

    #region Enable & Disable Functions

    private void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }

    #endregion
}
