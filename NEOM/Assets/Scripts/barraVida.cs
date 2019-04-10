using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class barraVida : MonoBehaviour
{

    private Image barra;
    public Player vida;
   

    void Start()
    {
        barra = GetComponent<Image>();
        
    }
    void Update()
    {
       
        barra.fillAmount = (vida.health/ 100f);
    }

}
