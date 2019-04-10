using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class barraVida : MonoBehaviour {

    Image barra;
    public Player vida;

     void Start()
    {  
            barra = GetComponent<Image> ();
            
             
    }
    void Update()
    {
        barra.fillAmount = (vida / 100f);
    }
    
}
