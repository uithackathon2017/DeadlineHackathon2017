using UnityEngine;
using System.Collections;

public class TankProjectile : MonoBehaviour
{

    public float Speed;

    public float Lifetime;

    void Start()
    {
        Invoke("DestroySelf", Lifetime);
        Debug.Log("spawn");
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
	
	// LateUpdate is called once per frame
	void Update ()
	{
	    transform.position = transform.position + transform.forward*Speed*Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
