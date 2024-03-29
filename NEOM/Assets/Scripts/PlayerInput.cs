﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]

public class PlayerInput : MonoBehaviour {

    [HideInInspector]public float horizontal;
    [HideInInspector]public bool crouchHeld;
    [HideInInspector]public bool crouchPressed;
    [HideInInspector] public bool reset;

    bool readyToClear;
	
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
        crouchHeld = false;
        crouchPressed = false;
        reset = false;
        readyToClear = false;
    }

    void ProcessInputs()
    {
        horizontal += Input.GetAxis("Horizontal");

        reset = Input.GetButtonDown("Jump");

        crouchHeld = crouchHeld || Input.GetButton("Crouch");
        crouchPressed = crouchPressed || Input.GetButtonDown("Crouch");
    }
}
