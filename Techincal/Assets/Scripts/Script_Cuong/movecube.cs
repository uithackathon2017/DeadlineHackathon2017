using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecube : MonoBehaviour {
	// Use this for initialization
    Vector3 newPos = new Vector3(0,0,0);
    Vector3 defaultPos = new Vector3();
    public float velocity = 200.0f;
	void Start () {
        newPos = this.transform.position;
        defaultPos = newPos;
	}
	
	// Update is called once per frame
	void Update () {
        newPos = transform.position;
        newPos.z -= velocity * Time.deltaTime;
        float newX = (float)(newPos.z - defaultPos.z) / 200 * 3.14f;
        newPos.x = defaultPos.x + Mathf.Sin(newX) * 100;
        this.transform.position = newPos;
	}
}
