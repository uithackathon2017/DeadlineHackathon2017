using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {
    public GameObject obj_to_Spawn;
    public float time_Spawn = 5.0f;
    float timer;
	// Use this for initialization
	void Start () {
        Instantiate(obj_to_Spawn);
    }
	
	// Update is called once per frame
	void Update () {
		if((timer += Time.deltaTime) >= time_Spawn)
        {
            Instantiate(obj_to_Spawn);
            timer = 0;
        }
	}
}
