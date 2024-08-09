using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float flightInput;
    [SerializeField] bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        speed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = player.GetComponent<PlayerInput>().GetHorizontalInput();
        verticalInput = player.GetComponent<PlayerInput>().GetVerticalInput();
        flightInput = player.GetComponent<PlayerInput>().GetflightInput();

        Vector3 inputFromPlayer = new Vector3 (horizontalInput, flightInput, verticalInput);
        inputFromPlayer.Normalize();
        transform.Translate (inputFromPlayer * speed * Time.deltaTime);

        isSprinting = player.GetComponent<PlayerInput>().GetIsSprinting();
        if (isSprinting)
        {
            speed = 50f;
        }
        else if (!isSprinting)
        {
            speed = 15f;
        }

    }
}
