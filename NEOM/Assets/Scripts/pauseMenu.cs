using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    bool pause = false;
    public GameObject PauseMenu;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!pause)
            {
                Instantiate(PauseMenu);
                pause = true;
            }
            else
            {
                pause = false;
            }
        }
    }
}
