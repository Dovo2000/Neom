using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicafondo : MonoBehaviour {

    //Play Global
    private static Musicafondo instance = null;
    public static Musicafondo Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    } 

}
