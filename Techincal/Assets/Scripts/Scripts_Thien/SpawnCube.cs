//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Spawn_Cube : MonoBehaviour
//{
//    public GameObject obj_to_Spawn;
//    public float time_Spawn = 5.0f;
//    float timer;
//    public Transform m_trfPositionSpawn;
//    public bool m_canSpawn = false;
//    // Use this for initialization
//    void Start()
//    {
//        timer = 0;
//        Instantiate(obj_to_Spawn);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(!m_canSpawn)
//        {
//            return;
//        }

//        if ((timer += Time.deltaTime) >= time_Spawn)
//        {
//            Instantiate(obj_to_Spawn).transform.position = m_trfPositionSpawn.position;
//            timer = 0;
//        }
//    }
//}
