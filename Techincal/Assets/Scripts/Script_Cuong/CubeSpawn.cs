//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CubeSpawn : MonoBehaviour {
//    public GameObject cube;
//    public float timer;
//    public bool m_isSpawn = false;
//    public Transform m_trfPositionSpawn1;
//	// Use this for initialization
//	void Start () {
//        Instantiate(cube);
//        timer = 0f;
//	}

//    // Update is called once per frame
//    void Update() {
//        if (!m_isSpawn)
//        {
//            return;
//        }
//        timer += Time.deltaTime;
//		if(timer >= 5){
//            GameObject fb =  Instantiate(cube);
//            fb.transform.position = m_trfPositionSpawn1.position;
//            timer = 0;
//        }
//	}
//}
