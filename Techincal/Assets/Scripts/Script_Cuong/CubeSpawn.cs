using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour {
    public GameObject cube;
    public float timer;
	// Use this for initialization
	void Start () {
        Instantiate(cube);
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if(timer >= 5){
            Instantiate(cube);
            timer = 0;
        }
	}
}
