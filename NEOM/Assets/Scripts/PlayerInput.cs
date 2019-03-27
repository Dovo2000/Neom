﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]

public class PlayerInput : MonoBehaviour {

    [HideInInspector]public float horizontal;
    [HideInInspector]public bool jumpHeld;
    [HideInInspector]public bool jumpPressed;

    bool readyToClear;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Limpiar los anteriores datos de input existentes
        ClearInput();

        //Si acaba el juego habría que salir del update a través de un  return
        ProcessInputs();

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
    }
    void FixedUpdate()
    {

        readyToClear = true;

    }

    void ClearInput()
    {
        // Si no hace falta limpiar inputs, salir
        if (!readyToClear)
        {
            return;
        }
        // Reset de Inputs
        horizontal = 0f;
        jumpPressed = false;
        jumpHeld = false;

        readyToClear = false;
    }

    void ProcessInputs()
    {
        horizontal += Input.GetAxis("Horizontal");

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld || Input.GetButton("Jump");
    }
}