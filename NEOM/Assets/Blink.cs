using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    Color colorToTurnTo = new Color(224, 92, 221);
    Color colorByDefault = Color.white;
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Blinking()
    {
       
        GetComponent<Renderer>().material.color = colorToTurnTo;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = colorByDefault;
        yield return new WaitForSeconds(0.1f);
    }
}
