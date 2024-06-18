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
    [SerializeField] bool canDisableCam;

    [SerializeField] GameObject reticle;
    [SerializeField] GameObject buildMenu;
    [SerializeField] GameObject controlTexts;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scroll.value = 1;
        buildMenu.SetActive(false);
        reticle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        buildMenuIsOpen = player.GetComponent<PlayerInput>().GetBuildMenuIsOpen();

        if (buildMenuIsOpen)
        {
            EnableCursor();
            buildMenu.SetActive(true);
            controlTexts.SetActive(false);
        }
        else if (!buildMenuIsOpen)
        {
            DisableCursor();
            buildMenu.SetActive(false);
            controlTexts.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Break();
        }

    }

    void EnableCursor()
    {
        if (!canDisableCam)
        {
            cam.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            reticle.SetActive(false);
        }
    }
    void DisableCursor()
    {
        if (!canDisableCam)
        {
            cam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            reticle.SetActive(true);
        }
    }

    public void SetBuildMenuIsOpenFalse()
    {
        buildMenuIsOpen = false;
    }
}
