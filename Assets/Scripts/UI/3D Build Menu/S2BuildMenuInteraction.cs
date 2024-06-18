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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;

        gameObject.transform.Rotate(0, Input.mouseScrollDelta.y * speed, 0);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000f, layerMask))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //Debug.Log("Did Hit");
            float yValue = hit.point.y;
            float zValue = hit.point.z;
            float xValue = hit.point.x;
            Vector3 hitPosition = new Vector3(xValue, yValue, zValue);
            

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked");
                GameObject build = hit.transform.gameObject.GetComponent<S2BuildPieceSystem>().GetBuildPrefab();
                player.GetComponent<S1PlaceSelectedBuild>().BuildToPlace(build);
                player.GetComponent<S1PlaceSelectedBuild>().canBuild = true;
                player.GetComponent<PlayerInput>().UpdateMenuBool(false);
            }

        }
    }
}
