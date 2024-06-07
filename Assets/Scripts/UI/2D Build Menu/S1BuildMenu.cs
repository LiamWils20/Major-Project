using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class S1BuildMenu : MonoBehaviour
{

    #region Menu Functionality
    [SerializeField] GameObject[] buildPrefabs;
    [SerializeField] GameObject[] all;
    [SerializeField] LayerMask layer;
    [SerializeField] S1PlaceSelectedBuild script;
    [SerializeField] PlayerInput input;

    [SerializeField] Button allBuildablesBtn;
    [SerializeField] Button buildingsBtn;
    #endregion

    private void Awake()
    {
        all = GameObject.FindGameObjectsWithTag("BuildUI");

        allBuildablesBtn.onClick.AddListener(() =>
        {
            foreach (GameObject t in all)
            {
                t.SetActive(true);
            }
        });

        buildingsBtn.onClick.AddListener(() =>
        {
            foreach(GameObject t in all)
            {
                if (t.layer == layer)
                {
                    t.SetActive(true);
                }
                else if (t.layer != layer)
                {
                    t.SetActive(false);
                }
            }
        });
    }

    public void S1BuildMenuButton(int ID)
    {
        int i = ID - 1;
        script.BuildToPlace(buildPrefabs[i]);
        Debug.Log("Selected Build ID:" + i);
        script.canBuild = true;
        input.UpdateMenuBool(false);
    }
}
