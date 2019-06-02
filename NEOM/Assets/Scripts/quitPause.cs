using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitPause : MonoBehaviour {

    bool pause = true;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause)
            {
                pause = true;
            }
            else
            {
                Destroy(gameObject);
                pause = false;
            }
        }
    }
}
