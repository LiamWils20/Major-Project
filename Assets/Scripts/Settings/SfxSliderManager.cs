using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxSliderManager : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        // Master Volume Slider
        sfxSlider.value = AudioManager.instance.sfxMixer;
        sfxSlider.value = mixer;
        sfxSlider.onValueChanged.AddListener((ms) =>
        {
            mixer = sfxSlider.value;
            AudioManager.instance.sfxMixer = sfxSlider.value;
        });
    }
}
