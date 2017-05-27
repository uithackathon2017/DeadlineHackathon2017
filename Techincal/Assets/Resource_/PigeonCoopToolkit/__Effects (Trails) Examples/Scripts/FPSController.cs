using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour
{
    public Animator CamAnimator, WeaponAnimator;

    public float moveSpeed;

    public Camera cameraAR;
    // 
    public LayerMask mask;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        //CamAnimator.SetBool("Running", Input.GetKey(KeyCode.W));
        //WeaponAnimator.SetBool("Fire", Input.GetKey(KeyCode.Space));

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        //}

        // collision
        
    }

    public void onFireButton()
    {
        Debug.Log("click");
        WeaponAnimator.SetBool("Fire", true);
        Shoot();    
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraAR.transform.position, cameraAR.transform.forward, out hit, 1000.0f, mask))
        {
            if (hit.transform.tag == "Item")
            {
                //Debug.Log("ok!");
                BaseItem m_item = hit.transform.GetComponent<BaseItem>();
                //CoregameController.Instance.
                //Destroy(hit.transform.gameObject);
                ManagerObject.Instance.DespawnObject(hit.transform.gameObject);
            }
        }
    }

    [ContextMenu("test")]
    public void stopFire()
    {
        WeaponAnimator.SetBool("Fire", false);
    }
}
