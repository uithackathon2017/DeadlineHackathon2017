using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click_start : MonoBehaviour {
    //public Button btn;
    public GameObject obj,obj1;
    //public Boolean clicked;
    //public Canvas can;
    //public Canvas canvas1, canvas2;
    
	// Use this for initialization
	void Start () {
       

	}

    public void button_exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void button_instruction()
    {
        Debug.Log("instrcution");
        obj.SetActive(true);
        obj1.SetActive(false);
        
        //clicked = true;
    }

    public void button_highscore()
    {
        Debug.Log("high score");
    }

    public void button_statrt()
    {
        Debug.Log("click start");
        Application.LoadLevel(1);
    }

	// Update is called once per frame
	void Update () {
        //button_statrt();

	}
}
