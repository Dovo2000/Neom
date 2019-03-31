using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowtime : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
           

            else
                Time.timeScale = 1.0f;

            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

    }
}