using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActivations : MonoBehaviour
{
    [SerializeField] Scrollbar scroll;

    [SerializeField] CameraMover cam;
    [SerializeField] GameObject player;
    [SerializeField] bool buildMenuIsOpen;

    [SerializeField] GameObject buildMenu;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scroll.value = 1;
        buildMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        buildMenuIsOpen = player.GetComponent<PlayerInput>().GetBuildMenuIsOpen();

        if (buildMenuIsOpen)
        {
            EnableCursor();
            buildMenu.SetActive(true);
        }
        else if (!buildMenuIsOpen)
        {
            DisableCursor();
            buildMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Break();
        }

    }

    void EnableCursor()
    {
        cam.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void DisableCursor()
    {
        cam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetBuildMenuIsOpenFalse()
    {
        buildMenuIsOpen = false;
    }
}
