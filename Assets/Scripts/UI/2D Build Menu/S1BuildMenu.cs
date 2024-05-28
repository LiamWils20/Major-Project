using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1BuildMenu : MonoBehaviour
{
    [SerializeField] Scrollbar scroll;

    #region Menu Functionality
    [SerializeField] GameObject[] buildPrefabs;
    [SerializeField] Mesh[] meshPrefabs;
    [SerializeField] S1PlaceSelectedBuild script;
    [SerializeField] PlayerInput input;
    #endregion

    #region Build Menu Buttons
    [Header("Build Menu Buttons")]
    [SerializeField] Button slotOne;
    [SerializeField] Button slotTwo;
    [SerializeField] Button slotThree;
    [SerializeField] Button slotFour;
    [SerializeField] Button slotFive;
    #endregion

    private void Awake()
    {
        #region Build Menu Button Functionality
        slotOne.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[0], meshPrefabs[0]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotTwo.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[1], meshPrefabs[1]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotThree.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[2], meshPrefabs[2]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotFour.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[3], meshPrefabs[3]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotFive.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[4], meshPrefabs[4]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        scroll.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
