using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class barraVida : MonoBehaviour
{

    private Image barra;
   
   

    void Start()
    {
        barra = GetComponent<Image>();
        
    }
    void Update()
    {
       
        barra.fillAmount = (Player.health/ 100f);

        if(Player.health <= 50)
        {
            barra.color = Color.red;
        }
    }

}
