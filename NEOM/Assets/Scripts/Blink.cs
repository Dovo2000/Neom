using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public float alpha;
	
	void Start () {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(255,255,255, alpha);
    }
	
	
	void Update () {
		
	}

    public IEnumerator Blinking()
    {
        if (ToggleFondo.Efectos == true)
        {

            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(13, 0, 255, alpha);
            yield return new WaitForSeconds(0.05f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
