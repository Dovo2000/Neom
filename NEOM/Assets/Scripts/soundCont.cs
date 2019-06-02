using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class soundCont : MonoBehaviour {

    public static float musicVolume = 0.8f;

    public static float SetVolumeFX = 0.8f;

    private void Start()
    {
        musicVolume = 1f;
        SetVolumeFX = 1f;
    }

    void Update () {

        Musicafondo.instance.musicSource.volume = musicVolume;
        Musicafondo.instance.efxSource.volume = SetVolumeFX;
        Musicafondo.instance.efxSourceEnemy.volume = SetVolumeFX;
        DontDestroyOnLoad(this.gameObject);

	}

    
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    public void SetVolumeFx(float vol2)
    {
        SetVolumeFX = vol2;
    }
}
