using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class soundCont : MonoBehaviour {

   //rivate AudioSource audioSrc;

    private static float musicVolume = 1f;

    private static float SetVolumeFX = 1f;

    //public static Slider slider = GetComponent<Slider>();
    private void Start()
    {
        musicVolume = Musicafondo.instance.musicSource.volume;
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
