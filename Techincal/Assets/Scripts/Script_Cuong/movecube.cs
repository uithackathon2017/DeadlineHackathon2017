using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecube : MonoBehaviour {
	// Use this for initialization
    Vector3 newPos = new Vector3(0,0,0);
    public float velocity = 50.0f;
	void Start () {
        newPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        newPos = transform.position;
        newPos.z -= velocity * Time.deltaTime;
        newPos.x += (float) (Mathf.Sin(Time.time) * 50 * Time.deltaTime);
        this.transform.position = newPos;
	}
}
