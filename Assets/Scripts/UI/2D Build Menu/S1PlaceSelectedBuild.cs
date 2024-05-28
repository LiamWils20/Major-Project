using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class S1PlaceSelectedBuild : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Camera cam;
    [SerializeField] GameObject buildToPlace;
    [SerializeField] Mesh meshToPlace;
    [SerializeField] GameObject build;
    [SerializeField] Material mat;
    [SerializeField] public bool canBuild;
    [SerializeField] int timer;
    [SerializeField] float speed;

    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (canBuild)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000f, layerMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                //Debug.Log("Did Hit");
                float yValue = hit.point.y;
                float zValue = hit.point.z;
                float xValue = hit.point.x;
                Vector3 hitPosition = new Vector3(xValue, yValue, zValue);
                if(timer == 0)
                {
                    timer = 1;
                    build = new GameObject();
                    build.AddComponent<MeshFilter>();
                    build.AddComponent<MeshRenderer>();
                    build.GetComponent<MeshFilter>().mesh = meshToPlace;
                    build.gameObject.GetComponent<MeshRenderer>().material = mat;
                    build.transform.localScale = new Vector3(5, 5, 5);
                }
                build.transform.position = hitPosition;
                build.transform.Rotate(0, Input.mouseScrollDelta.y * speed, 0);

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked");
                    GameObject b = Instantiate(buildToPlace);
                    b.transform.position = build.transform.position;
                    b.transform.rotation = build.transform.rotation;
                    b.transform.localScale = new Vector3(5, 5, 5);
                    b.layer = 6;
                    Destroy(build);

                    gameObject.GetComponent<PlayerInput>().UpdateMenuBool(true);
                    canBuild = false;
                    timer = 0;
                }

            }
        }
    }

    public void BuildToPlace(GameObject b, Mesh m)
    {
        buildToPlace = b;
        meshToPlace = m;
    }
}
