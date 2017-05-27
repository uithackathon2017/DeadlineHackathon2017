using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemsType
{
    ItemGirl,
    ItemDeadline,
    ItemMoney
}
public class MoveCubeJump : BaseItem {
    Vector3 pos;
    public float velocity = -30.0f;
    public float velocity_Y = 90.0f;

    public float time_Run = 3; // const 
    float timeRun = 0; // timecount

    Vector3 newPos;
    public float jump_High;
    float max_Y;
    bool isMax = false;

    // Use this for initialization
    void Start()
    {
        pos = this.transform.position;
        newPos = pos;
        max_Y = pos.y + jump_High;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRun <= time_Run)
        {
            //Debug.Log("Quay ve");
            isMax = false;
            if ((timeRun += Time.deltaTime) >= time_Run)
            {
                //Debug.Log("Time before:" + timeRun);
                newPos.y += Time.deltaTime * velocity_Y;
            }
        }
        else
        {
            if (!isMax)
            {
                newPos.y += Time.deltaTime * velocity_Y;
                //Debug.Log("Dang Tang" + newPos.y);
            }
            else
            {
                newPos.y += Time.deltaTime * -velocity_Y;
                //Debug.Log("Dang Giam" + newPos.y);
            }
            if (newPos.y >= jump_High)
                isMax = true;
            if(newPos.y <= pos.y)
            {
                timeRun = 0;
            }

        }
        
        newPos.z += Time.deltaTime * velocity;
        this.transform.position = newPos;
    }
}
