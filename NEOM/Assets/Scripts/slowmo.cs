using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmo : MonoBehaviour {

	public float slowdown = 0.0f;
    public float slowdowntime = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {


            Time.timeScale += (1f / slowdowntime) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }


    }

    
}
