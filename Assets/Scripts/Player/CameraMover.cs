using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float MouseX;
    public float MouseY;

    public Vector2 turn;
    public float sensitivity = 0.1f;
    public Vector2 deltaMove;
    public float speed = 0.5f;
    public GameObject mover;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = player.GetComponent<PlayerInput>().GetMouseX();
        MouseY = player.GetComponent<PlayerInput>().GetMouseY();

        turn.x += MouseX * sensitivity;
        turn.y = Mathf.Clamp(turn.y, -90f, 90f);
        turn.y += MouseY * sensitivity;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);

        deltaMove = new Vector3(MouseY, 0, MouseX) / speed;
    }

    internal Vector3 ViewportToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
