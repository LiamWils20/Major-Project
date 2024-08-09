using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    #region Button Variables
    [SerializeField] Button audioBtn;
    [SerializeField] Button videoBtn;
    [SerializeField] Button backBtn;
    #endregion

    [SerializeField] GameObject audioPage;
    [SerializeField] GameObject videoPage;
    [SerializeField] GameObject optionsPage;

    private void Awake()
    {
        audioBtn.onClick.AddListener(() =>
        {
            audioPage.SetActive(true);
            videoPage.SetActive(false);
        });

        videoBtn.onClick.AddListener(() =>
        {
            audioPage.SetActive(false);
            videoPage.SetActive(true);
        });

        backBtn.onClick.AddListener(() =>
        {
            audioPage.SetActive(true);
            videoPage.SetActive(false);
            optionsPage.SetActive(false);

        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
