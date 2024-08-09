using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    [SerializeField] UIActivations script;
    [SerializeField] CameraMover cameraScript;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject buttonPage;
    [SerializeField] GameObject controlPage;
    [SerializeField] GameObject optionsPage;
    [SerializeField] bool paused;

    [SerializeField] Button backBtn;
    [SerializeField] Button optionsBackBtn;
    [SerializeField] Button feedbackBtn;
    [SerializeField] Button controlsBtn;
    [SerializeField] Button optionsBtn;
    [SerializeField] Button mainMneuBtn;

    private void Awake()
    {
        feedbackBtn.onClick.AddListener(() =>
        {
            Application.OpenURL("https://forms.gle/QCjjKr9TKtfbL2oV9");
            PlayClick();
        });

        controlsBtn.onClick.AddListener(() =>
        {
            buttonPage.SetActive(false);
            controlPage.SetActive(true);
            PlayClick();
        });

        optionsBtn.onClick.AddListener(() =>
        {
            buttonPage.SetActive(false);
            controlPage.SetActive(false);
            optionsPage.SetActive(true);
            PlayClick();
        });

        backBtn.onClick.AddListener(() =>
        {
            buttonPage.SetActive(true);
            controlPage.SetActive(false);
            PlayClick();
        });

        optionsBackBtn.onClick.AddListener(() =>
        {
            buttonPage.SetActive(true);
            controlPage.SetActive(false);
            optionsPage.SetActive(false);
            PlayClick();
        });

        mainMneuBtn.onClick.AddListener(() =>
        {
            PlayClick();
            SceneManager.LoadScene("Main Menu");
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<UIActivations>();
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMover>();
        pauseMenu.SetActive(false);
        controlPage.SetActive(false);
        optionsPage.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                script.enabled = false;
                cameraScript.enabled = false;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (paused)
            {
                paused = false;
                script.enabled = true;
                cameraScript.enabled = true;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void PlayClick()
    {
        int r = Random.Range(0, clips.Length);
        audioSource.clip = clips[r];
        audioSource.Play();
    }
}
