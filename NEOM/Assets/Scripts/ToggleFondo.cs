using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFondo : MonoBehaviour {

    public static bool Efectos = true;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activarDesactivar()
    {
        if(Efectos == true)
        {
            Efectos = false;
        }

        else if(Efectos == false)
        {
            Efectos = true;
        }
            
    }
}
