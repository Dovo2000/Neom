using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraVida : MonoBehaviour {

    private Transform barra;

	private void Start () {
        barra = transform.Find("Barra");
	}
	public void SetSize(float sizeNormal)
    {
        barra.localScale = new Vector3(sizeNormal, 1f);
    }
}
