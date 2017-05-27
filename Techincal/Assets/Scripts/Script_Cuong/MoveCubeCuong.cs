using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeCuong : MonoBehaviour
{
    public float m_angle = 2.0f;
    public float velocity = 2.0f;
    // Use this for initialization
    Vector3 newPos = new Vector3(0, 0, 0);
    Vector3 defaultPos = new Vector3();

    void Start()
    {
        newPos = this.transform.position;
        defaultPos = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        newPos.z -= velocity * Time.deltaTime;
        float newX = (float)(newPos.z - defaultPos.z) / 30 * 3.14f;
        newPos.x = defaultPos.x + Mathf.Sin(newX) * m_angle;
        this.transform.position = newPos;
    }
}
