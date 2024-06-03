using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1BuildMenu : MonoBehaviour
{

    #region Menu Functionality
    [SerializeField] GameObject[] buildPrefabs;
    [SerializeField] Mesh[] meshPrefabs;
    [SerializeField] S1PlaceSelectedBuild script;
    [SerializeField] PlayerInput input;
    #endregion

    #region Build Menu Buttons
    #region Slots 1-9 Buttons
    [Header("Slots 1-9 Buttons")]
    [SerializeField] Button slotOne;
    [SerializeField] Button slotTwo;
    [SerializeField] Button slotThree;
    [SerializeField] Button slotFour;
    [SerializeField] Button slotFive;
    [SerializeField] Button slotSix;
    [SerializeField] Button slotSeven;
    [SerializeField] Button slotEight;
    [SerializeField] Button slotNine;
    #endregion

    #region Slots 10-19 Buttons
    [Header("Slots 10-19 Buttons")]
    [SerializeField] Button slotTen;
    [SerializeField] Button slotEleven;
    [SerializeField] Button slotTwelve;
    [SerializeField] Button slotThirteen;
    [SerializeField] Button slotFourteen;
    [SerializeField] Button slotFifteen;
    [SerializeField] Button slotSixteen;
    [SerializeField] Button slotSeventeen;
    [SerializeField] Button slotEighteen;
    [SerializeField] Button slotNineteen;
    #endregion

    #endregion

    private void Awake()
    {
        #region Build Menu Button Functionality

        #region Slot 1-9
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

        slotSix.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[5], meshPrefabs[5]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotSeven.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[6], meshPrefabs[6]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotEight.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[7], meshPrefabs[7]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotNine.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[8], meshPrefabs[8]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });
        #endregion

        #region Slot 10-19
        slotTen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[9], meshPrefabs[9]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotEleven.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[10], meshPrefabs[10]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotTwelve.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[11], meshPrefabs[11]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotThirteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[12], meshPrefabs[12]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotFourteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[13], meshPrefabs[13]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotFifteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[14], meshPrefabs[14]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotSixteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[15], meshPrefabs[15]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotSeventeen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[16], meshPrefabs[16]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotEighteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[17], meshPrefabs[17]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });

        slotNineteen.onClick.AddListener(() =>
        {
            script.BuildToPlace(buildPrefabs[18], meshPrefabs[18]);
            script.canBuild = true;
            input.UpdateMenuBool(false);
        });
        #endregion

        #endregion
    }
}
