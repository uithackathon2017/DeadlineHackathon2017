using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private Vector3 pos;
    public float velocity = -30.0f;
    float defaultVelocity;
    // Use this for initialization
    void Start()
    {
        pos = this.transform.position;
        defaultVelocity = this.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        pos.z += Time.deltaTime * velocity;
        this.transform.position = pos;
    }
}
