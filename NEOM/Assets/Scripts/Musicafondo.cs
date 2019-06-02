using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicafondo : MonoBehaviour {

    //Play Global
    public AudioSource efxSource;
    public AudioSource efxSourceEnemy;
    public AudioSource musicSource;
    public static Musicafondo instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);

        //DontDestroyOnLoad(this.gameObject);
    } 

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void PlaySingleEnemy(AudioClip clip)
    {
        efxSourceEnemy.clip = clip;
        efxSourceEnemy.Play();
    }

}
