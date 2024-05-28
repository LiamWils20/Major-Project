using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputActions input;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] bool isSprinting;
    [SerializeField] bool buildMenuIsOpen;

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

        input.Player.Sprint.started += StartSprint;
        input.Player.Sprint.canceled += CancelSprint;
        #endregion

        #region Menu UI Inputs
        input.Player.BuildMenu.started += BuildMenu;
        #endregion

        #region Camera Controls
        input.Player.MouseX.started += MouseX;
        input.Player.MouseX.performed += MouseX;
        input.Player.MouseX.canceled += MouseX;

        input.Player.MouseY.started += MouseY;
        input.Player.MouseY.performed += MouseY;
        input.Player.MouseY.canceled += MouseY;
        #endregion
    }

    #region 'Get' Functions

    public float GetHorizontalInput() { return horizontalInput; }
    public float GetVerticalInput() { return verticalInput; }
    public bool GetIsSprinting() { return isSprinting; }
    public bool GetBuildMenuIsOpen() { return buildMenuIsOpen; }
    public float GetMouseX() {  return mouseX; }
    public float GetMouseY() {  return mouseY; }

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

    void StartSprint(InputAction.CallbackContext c)
    {
        isSprinting = true;
    }
    void CancelSprint(InputAction.CallbackContext c)
    {
        isSprinting = false;
    }

    #endregion

    #region Menu UI Inputs
    void BuildMenu(InputAction.CallbackContext c)
    {
        if (!buildMenuIsOpen)
        {
            buildMenuIsOpen = true;
        }
        else if (buildMenuIsOpen)
        {
            buildMenuIsOpen = false;
        }
    }
    #endregion

    #region Camera Movement Functions
    void MouseX(InputAction.CallbackContext c)
    {
        mouseX = c.ReadValue<float>();
    }
    void MouseY(InputAction.CallbackContext c)
    {
        mouseY = c.ReadValue<float>();
    }
    #endregion

    public void UpdateMenuBool(bool s)
    {
        buildMenuIsOpen = s;
    }

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
