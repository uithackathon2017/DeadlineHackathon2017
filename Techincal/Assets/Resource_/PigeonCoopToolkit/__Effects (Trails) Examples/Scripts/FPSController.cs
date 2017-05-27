﻿using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour
{

    public Animator CamAnimator, WeaponAnimator;

    public float moveSpeed;
	
	// Update is called once per frame
	void Update ()
	{
        CamAnimator.SetBool("Running", Input.GetKey(KeyCode.W));
        WeaponAnimator.SetBool("Fire", Input.GetKey(KeyCode.Space));

        if( Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward*moveSpeed*Time.deltaTime;
        }
    }
    public void onButtonShoot()
    {
        Debug.Log("fire!");

        WeaponAnimator.SetBool("Fire", true);
    }
}
