﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaMenu : MonoBehaviour {

    public AudioSource musicSource;
    public static MusicaMenu instanceMenu = null;

    void Awake()
    {
        if (instanceMenu == null)
            instanceMenu = this;
        else if (instanceMenu != null)
            Destroy(this.gameObject);
        
    }
}
