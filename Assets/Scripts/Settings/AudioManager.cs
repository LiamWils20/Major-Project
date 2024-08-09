using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public float masterMixer;
    public float musicMixer;
    public float sfxMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; ;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ValueChanged()
    {
        masterMixer = 0;
        musicMixer = 0;
        sfxMixer = 0;
    }
}
