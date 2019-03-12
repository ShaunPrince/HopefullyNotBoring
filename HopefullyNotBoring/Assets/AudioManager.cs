using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [HideInInspector]
    public AudioSource musicSource;
    [HideInInspector]
    public AudioSource SFXSource;

    private void Awake() //called when our object wakes up
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);        
    }

    public void playMusic(AudioClip music) //can be called by other scripts to play music
    {
        musicSource.clip = music;

        musicSource.Play();
    }

    public void playSFX(AudioClip SFX) //can be called by other scripts to play SFX
    {
        SFXSource.clip = SFX;

        SFXSource.Play();
    }
}
