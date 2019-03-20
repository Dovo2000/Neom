using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public GameObject enemy;
    public int health = 100;

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            Destroy(enemy);
        }
    }
}
