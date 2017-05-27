using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeStop : MonoBehaviour {
    Vector3 pos;
    public float velocity = -30.0f;
    public float time_Run = 2;
    public float time_Delay = 1;
    float timeRun = 0;
    float timeDelay = 0;
    float defaultVelocity = 0;
    // Use this for initialization
    void Start()
    {
        pos = this.transform.position;
        defaultVelocity = this.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDelay == 0)
        {
            if ((timeRun += Time.deltaTime) >= time_Run)
            {
                Debug.Log("Time before:" + timeRun);
                this.velocity = 0;

            }
        }
        if (timeRun >= time_Run)
        {
            if ((timeDelay += Time.deltaTime) >= time_Delay)
            {
                this.velocity = defaultVelocity;
                Debug.Log("Time after:" + timeDelay);
                timeDelay = 0;
                timeRun = 0;
            }
        }
        pos.z += Time.deltaTime * velocity;
        this.transform.position = pos;
    }
}
