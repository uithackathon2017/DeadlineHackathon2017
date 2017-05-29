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
        if (Physics.Raycast(cameraAR.transform.position, cameraAR.transform.forward, out hit, 5000.0f, mask))
        {
            if (hit.transform.tag == "Item")
            {
                //Debug.Log("ok!");
                BaseItem m_item = hit.transform.GetComponent<BaseItem>();
                CoregameController.Instance.SubScoreByType(m_item.m_type);
                //CoregameController.Instance.
                //Destroy(hit.transform.gameObject);
                //Debug.Log("...................:"+hit.transform.name);
                //SpawnManager.Instance.RemoveObjectDie(m_item.m_type, hit.transform.name);
                SpawnManager.Instance.RemoveObjectDie(hit.transform);
                ManagerObject.Instance.SpawnObjectByType(ObjectType.PARTICAL_ENEMY_DIE).transform.position = hit.transform.position;
                ManagerObject.Instance.DespawnObject(hit.transform.gameObject);
            }
            else if(hit.transform.tag=="Ground")
            {
                //Debug.Log("ok!");
                ManagerObject.Instance.SpawnObjectByType(ObjectType.PARTICAL_ENEMY_DIE).transform.position = hit.transform.position;
            }
        }
    }

    [ContextMenu("test")]
    public void stopFire()
    {
        WeaponAnimator.SetBool("Fire", false);
    }
}
