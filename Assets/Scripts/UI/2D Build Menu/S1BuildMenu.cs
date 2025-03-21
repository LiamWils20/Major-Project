using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1BuildMenu : MonoBehaviour
{

    #region Menu Functionality
    [SerializeField] GameObject[] buildPrefabs;
    [SerializeField] LayerMask layer;
    [SerializeField] S1PlaceSelectedBuild script;
    [SerializeField] PlayerInput input;

    #endregion

    public void S1BuildMenuButton(int ID)
    {
        gameObject.GetComponent<PauseMenuManager>().PlayClick();
        int i = ID - 1;
        script.BuildToPlace(buildPrefabs[i]);
        Debug.Log("Selected Build ID:" + i);
        script.canBuild = true;
        input.UpdateMenuBool(false);
    }
}
