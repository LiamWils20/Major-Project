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
    [SerializeField] Button optionsBtn;
    [SerializeField] Button quitGame;
    #endregion

    [SerializeField] GameObject optionsPage;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    void Awake()
    {
        #region Main Menu
        sceneOne.onClick.AddListener(() =>
        {
            PlayClick();
            SceneManager.LoadScene("Scene 1 - 2D UI");
        });

        sceneTwo.onClick.AddListener(() =>
        {
            PlayClick();
            SceneManager.LoadScene("Scene 2 - 3D UI");
        });

        optionsBtn.onClick.AddListener(() =>
        {
            optionsPage.SetActive(true);
        });

        quitGame.onClick.AddListener(() =>
        {
            PlayClick();
            Application.Quit();
        });
        #endregion
    }

    private void Start()
    {
        optionsPage.SetActive(false);
    }

    void PlayClick()
    {
        int r = Random.Range(0, clips.Length);  
        audioSource.clip = clips[r];
        audioSource.Play();
    }
}
