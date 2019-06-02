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

    // Update is called once per frame
    void Update () {
        tiempoFinal = final - (inicio - (finalPausa - inicioPausa));
        Puntuacion.text = tiempoFinal.ToString();
	}
}
