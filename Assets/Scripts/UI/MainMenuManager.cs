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

    [Header("Online Buttons")]
    [SerializeField] Button agree;
    [SerializeField] Button disagree;
    [SerializeField] Button conAgree;
    [SerializeField] Button conDisagree;
    #endregion

    #region Online Things
    [SerializeField] bool onlineParticipation;
    [SerializeField] GameObject consentForm;
    [SerializeField] GameObject confirm;
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

        #region Consent Form
        agree.onClick.AddListener(() =>
        {
            confirm.SetActive(true);
        });

        disagree.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        #endregion

        #region Confirm Form
        conAgree.onClick.AddListener(() =>
        {
            consentForm.SetActive(false);
            confirm.SetActive(false);
        });

        conDisagree.onClick.AddListener(() =>
        {
            confirm.SetActive(false);
        });
        #endregion
    }

    private void Start()
    {
        if (onlineParticipation)
        {
            consentForm.SetActive(true);
            confirm.SetActive(false);
        }
        else
        {
            consentForm.SetActive(false);
            confirm.SetActive(false);
        }
    }
}
