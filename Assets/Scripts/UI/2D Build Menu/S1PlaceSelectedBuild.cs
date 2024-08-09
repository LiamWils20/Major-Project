using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class S1PlaceSelectedBuild : MonoBehaviour
{
    #region Control Bools
    [SerializeField] PlayerInput input; 
    [SerializeField] public bool canBuild;
    [SerializeField] public bool canMoveBuild;
    [SerializeField] bool canDelete;
    [SerializeField] bool clicked;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    #endregion

    [SerializeField] LayerMask layerMask;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Camera cam;
    [SerializeField] GameObject buildToPlace; // The GameObject which is to assist the other two objects spawnings
    [SerializeField] GameObject build; // The GameObject which is spawned and then follows the raycast hit point
    [SerializeField] GameObject b; // The GameObject which is spawned and stays where the player placed it until deleted
    [SerializeField] Material[] placingBuildMaterial;
    [SerializeField] GameObject deleteModeIndicator;
    [SerializeField] GameObject dustCloud;
    [SerializeField] GameObject spawnedCloud;
    [SerializeField] TMP_Text txt;
    
    [SerializeField] int timer;
    [SerializeField] float speed;
    [SerializeField] float moveBuildSpeed;

    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = gameObject.transform.GetChild(0).GetComponent<Camera>();
        input = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        canDelete = input.GetCanDelete();
        horizontalInput = input.GetBuildHorizontalInput();
        verticalInput = input.GetBuildVerticalInput();

        RaycastHit hit;
        if (canBuild)
        {
            if (!canMoveBuild && Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000f, layerMask))
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
                    build = Instantiate(buildToPlace);
                    build.transform.GetChild(0).GetComponent<MeshRenderer>().materials = placingBuildMaterial;
                    build.transform.localScale = new Vector3(5, 5, 5);
                    BuildHasChildren();
                    cam.transform.GetChild(0).gameObject.SetActive(false);
                }
                build.transform.position = hitPosition;
                build.transform.Rotate(0, Input.mouseScrollDelta.y * speed, 0);
                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.X))
                {
                    cam.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(build);
                    canBuild = false;
                    timer = 0;
                }
                
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked");
                    b = Instantiate(buildToPlace);
                    //b.AddComponent<MeshCollider>();
                    GivingChildrenCollider();
                    b.transform.GetChild(0).AddComponent<MeshCollider>();
                    b.transform.GetChild(0).GetComponent<MeshRenderer>().materials = b.GetComponent<MeshRenderer>().materials;
                    b.transform.position = build.transform.GetChild(0).transform.position;
                    b.transform.rotation = build.transform.GetChild(0).transform.rotation;
                    audioSource.Play();
                    b.transform.localScale = new Vector3(5, 5, 5);
                    b.layer = 6;
                    SpawnParticle();
                    Invoke(nameof(DeleteParticle), 10f);
                    Destroy(build);

                    cam.transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.GetComponent<PlayerInput>().UpdateMenuBool(true);
                    canBuild = false;
                    timer = 0;
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    build.transform.GetChild(0).transform.position = build.transform.position;
                    build.transform.GetChild(0).transform.rotation = build.transform.rotation;
                }

            }
            else if (canMoveBuild)
            {
                Vector3 inputFromPlayer = new Vector3(horizontalInput, 0, verticalInput);
                inputFromPlayer.Normalize();

                build.transform.GetChild(0).transform.Translate(inputFromPlayer * moveBuildSpeed * Time.deltaTime);
            }
        }
        else if (canDelete)
        {
            deleteModeIndicator.SetActive(true);
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000f, layerMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did Hit");

                if (hit.transform.gameObject.CompareTag("Build") && Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
        else if (!canDelete)
        {
            deleteModeIndicator.SetActive(false);
        }


        if (horizontalInput == -1 || horizontalInput == 1 || verticalInput == -1 || verticalInput == 1)
        {
            canMoveBuild = true;
        }
        else
        {
            canMoveBuild = false;
        }
    }

    void BuildHasChildren()
    {
        int children = build.transform.childCount;
        if (children >= 1)
        {
            Debug.Log("object has child");
            for (int i = 0; i < children; i++)
            {
                build.transform.GetChild(i).GetComponent<MeshRenderer>().materials = placingBuildMaterial;
            }
        }
    }
    void GivingChildrenCollider()
    {
        int children = build.transform.childCount;
        if (children >= 1)
        {
            Debug.Log("object has child");
            for (int i = 0; i < children; i++)
            {
                b.transform.GetChild(i).AddComponent<MeshCollider>();
            }
        }
    }
    void SpawnParticle()
    {
        spawnedCloud = Instantiate(dustCloud);
        spawnedCloud.transform.position = b.transform.position;
    }
    void DeleteParticle()
    {
        Destroy(spawnedCloud);
    }

    public void BuildToPlace(GameObject b)
    {
        buildToPlace = b;
    }
}
