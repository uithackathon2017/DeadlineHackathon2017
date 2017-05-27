using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {
    Vector3 pos;
    public float velocity = -30.0f;
	// Use this for initialization
	void Start () {
        pos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        pos.z += Time.deltaTime * velocity;
        this.transform.position = pos;
	}
}
