using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyNoMove : MonoBehaviour
{
    
    public int detectionRate = 4;
    bool detection = false;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void update()
    {
        if ((Vector2.Distance(transform.position, target.position) > detectionRate))
        {
            detection = false;
        }
    }
   
}
