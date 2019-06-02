using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class soundCont : MonoBehaviour {

   //rivate AudioSource audioSrc;

    public static float musicVolume = 1f;

    public static float SetVolumeFX = 1f;

    //public static Slider slider = GetComponent<Slider>();
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
