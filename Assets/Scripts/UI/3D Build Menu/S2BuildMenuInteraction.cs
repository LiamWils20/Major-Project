using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class S2BuildMenuInteraction : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    [SerializeField] float speed;

    [SerializeField] bool canBack; // Bool to say we can go back through ui tabs
    [SerializeField] GameObject buttonParent;
    [SerializeField] GameObject[] buildingSectionsParent; // Cartoon = 0, 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.transform.GetChild(0).gameObject;

        foreach (GameObject b in buildingSectionsParent)
        {
            b.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        canBack = player.GetComponent<UIActivations>().GetBuildOpen();

        gameObject.transform.position = player.transform.position;

        gameObject.transform.Rotate(0, Input.mouseScrollDelta.y * speed, 0);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000f, layerMask))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //Debug.Log("Did Hit");

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.gameObject.CompareTag("Roads"))
                {
                    buttonParent.SetActive(false);
                    buildingSectionsParent[0].SetActive(true);
                }
                else if (hit.transform.gameObject.CompareTag("Cartoon"))
                {
                    buttonParent.SetActive(false);
                    buildingSectionsParent[1].SetActive(true);
                }
                else if (hit.transform.gameObject.CompareTag("Decoration"))
                {
                    buttonParent.SetActive(false);
                    buildingSectionsParent[2].SetActive(true);
                }
                else if (hit.transform.gameObject.CompareTag("Houses"))
                {
                    buttonParent.SetActive(false);
                    buildingSectionsParent[3].SetActive(true);
                }
                else
                {
                    Debug.Log("Clicked");
                    GameObject build = hit.transform.gameObject.GetComponent<S2BuildPieceSystem>().GetBuildPrefab();
                    player.GetComponent<S1PlaceSelectedBuild>().BuildToPlace(build);
                    player.GetComponent<S1PlaceSelectedBuild>().canBuild = true;
                    player.GetComponent<PlayerInput>().UpdateMenuBool(false);
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                buttonParent.SetActive(true);
                foreach (GameObject b in buildingSectionsParent)
                {
                    b.SetActive(false);
                }
            }


        }
        else if (canBack && Input.GetMouseButtonDown(1))
        {
            buttonParent.SetActive(true);
            foreach (GameObject b in buildingSectionsParent)
            {
                b.SetActive(false);
            }
        }
    }
}
