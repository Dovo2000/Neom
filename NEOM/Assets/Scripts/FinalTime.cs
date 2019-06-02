using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalTime : MonoBehaviour {

    public static float inicio;
    public static float final;
    public static float inicioPausa;
    public static float finalPausa;
    public float tiempoFinal;

    [SerializeField] Text Puntuacion;
    [SerializeField] Text Chascarrillo;

    // Update is called once per frame
    void Update () {
        tiempoFinal = final - (inicio - (finalPausa - inicioPausa));
        Puntuacion.text = tiempoFinal.ToString();
        if (tiempoFinal > 45) Chascarrillo.text = "That was bad!";
        else if (tiempoFinal > 35 && tiempoFinal <= 45) Chascarrillo.text = "You can do it better!";
        else if (tiempoFinal <= 35) Chascarrillo.text = "Perfect!";
    }
}
