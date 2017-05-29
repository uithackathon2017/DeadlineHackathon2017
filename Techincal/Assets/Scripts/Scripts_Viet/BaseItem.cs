using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour {

    public ItemsType m_type;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Target"))
        {
            //Debug.Log("target");
            CoregameController.Instance.addScoreByType(this.m_type);
            SpawnManager.Instance.RemoveObjectDie(this.m_type, this.name);
            //Destroy();
            ManagerObject.Instance.DespawnObject(this.gameObject);
           
        }
    }
}
