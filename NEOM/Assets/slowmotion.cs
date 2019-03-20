using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0.5f;
        }
        else
            Time.timeScale = 1f;
	}
}
