using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        musicSlider.value = AudioManager.instance.musicMixer;
        musicSlider.value = mixer;
        musicSlider.onValueChanged.AddListener((ms) =>
        {
            mixer = musicSlider.value;
            AudioManager.instance.musicMixer = musicSlider.value;
        });
    }
}
