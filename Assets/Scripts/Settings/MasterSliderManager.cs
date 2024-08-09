using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSliderManager : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        masterSlider.value = AudioManager.instance.masterMixer;
        masterSlider.value = mixer;
        masterSlider.onValueChanged.AddListener((ms) =>
        {
            mixer = masterSlider.value;
            AudioManager.instance.masterMixer = masterSlider.value;
        });
    }
}
