using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    #region Button Objects
    [Header("Main Menu Objects")]
    [SerializeField] Button sceneOne;
    [SerializeField] Button sceneTwo;
    [SerializeField] Button quitGame;
    #endregion

    void Awake()
    {
        #region Main Menu
        sceneOne.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene 1 - 2D UI");
        });

        sceneTwo.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene 2 - 3D UI");
        });

        quitGame.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        #endregion
    }

    private void Start()
    {
        
    }
}
