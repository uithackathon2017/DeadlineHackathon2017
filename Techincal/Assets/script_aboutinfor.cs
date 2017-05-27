using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_aboutinfor : MonoBehaviour {
    
	// Use this for initialization
    
	void Start () {
		var panel = GameObject.Find("Canvas/Coregameplay/AboutInfor");
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
