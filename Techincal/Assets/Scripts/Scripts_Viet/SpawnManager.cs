using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoSingleton<SpawnManager> {
    public Transform m_positionSpawnItemFacebook;
    public Transform m_positionSpawnItemTime;
    public Transform m_positionSpawnItemMoney;

    public bool m_canSpawn = false;

    public float m_timeDelayOfFacebook = 8.0f;
    public float m_timeDelayOfMoney = 7.0f;
    public float m_timeDelayOfTime = 7.5f;

    //public List<Transform> m_listFaceBookItem = new List<Transform>();
    //public List<Transform> m_listTimeItem = new List<Transform>();
    //public List<Transform> m_listMoneyItem = new List<Transform>();

    public List<Transform> m_listAllItem = new List<Transform>();
    public void StartSpawnAll()
    {
        if(CoregameController.Instance.m_isStart && m_canSpawn)
        {
            StartSpawnFacebook();
            StartSpawnTime();
            StartSpawnMoney();
        }
    }

    public void StoptSpawnAll()
    {
        StopSpawnFacebook();
        StopSpawnTime();
        StopSpawnMoney();
        for(int i=0;i< m_listAllItem.Count;i++)
        {
            ManagerObject.Instance.DespawnObject(m_listAllItem[i].gameObject);
        }
        //for(int i=0;i< m_listFaceBookItem.Count;i++)
        //{
        //    ManagerObject.Instance.DespawnObject(m_listFaceBookItem[i].gameObject);
        //}
        //for (int i = 0; i < m_listTimeItem.Count; i++)
        //{
        //    ManagerObject.Instance.DespawnObject(m_listTimeItem[i].gameObject);
        //}
        //for (int i = 0; i < m_listMoneyItem.Count; i++)
        //{
        //    ManagerObject.Instance.DespawnObject(m_listMoneyItem[i].gameObject);
        //}
    }

    public void StartSpawnFacebook()
    {
        StopCoroutine("SpawnItemFaceBook");
        if (m_canSpawn)
            StartCoroutine("SpawnItemFaceBook");
    }

   

    //
    public void StartSpawnTime()
    {
        StopCoroutine("SpawnItemTime");
        if (m_canSpawn)
            StartCoroutine("SpawnItemTime");
    }
    //
    public void StartSpawnMoney()
    {
        StopCoroutine("SpawnItemMoney");
        if (m_canSpawn)
            StartCoroutine("SpawnItemMoney");
    }

    /// <summary>
    /// ............
    /// </summary>

    public void StopSpawnTime()
    {
        StopCoroutine("SpawnItemTime");

    }

    public void StopSpawnFacebook()
    {
        StopCoroutine("SpawnItemFaceBook");

    }

    public void StopSpawnMoney()
    {
        StopCoroutine("SpawnItemMoney");

    }
    // girl
    public IEnumerator SpawnItemFaceBook()
    {
        while(true)
        {
            Transform objFacebookprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_JUMP).transform;
            // m_listFaceBookItem.Add(objFacebookprefabs);
            m_listAllItem.Add(objFacebookprefabs);
            objFacebookprefabs.position = m_positionSpawnItemFacebook.position;
            yield return new WaitForSeconds(m_timeDelayOfFacebook);
        }
    }

    // deadline
    public IEnumerator SpawnItemTime()
    {
        while (true)
        {
            Transform objTimeprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_NORMAL).transform;
            //m_listTimeItem.Add(objTimeprefabs); // 
            m_listAllItem.Add(objTimeprefabs);
            objTimeprefabs.position = m_positionSpawnItemTime.position;
            yield return new WaitForSeconds(m_timeDelayOfTime);
        }
    }

    // money
    public IEnumerator SpawnItemMoney()
    {
        while (true)
        {
            Transform objMoneyprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_STOP).transform;
            //m_listMoneyItem.Add(objMoneyprefabs); // 
            m_listAllItem.Add(objMoneyprefabs);
            objMoneyprefabs.position = m_positionSpawnItemMoney.position;
            yield return new WaitForSeconds(m_timeDelayOfMoney);
        }
    }

    [ContextMenu("pause")]
    public void PauseWhenTrackingLost()
    {
        for(int i=0;i< m_listAllItem.Count;i++)
        {
            if (m_listAllItem[i] != null)
                m_listAllItem[i].gameObject.SetActive(false);
        }
        //for (int i = 0; i < m_listFaceBookItem.Count; i++)
        //{
        //    if (m_listFaceBookItem[i] != null)
        //        m_listFaceBookItem[i].gameObject.SetActive(false);
        //}
        //for (int i = 0; i < m_listMoneyItem.Count; i++)
        //{
        //    if (m_listMoneyItem[i] != null)
        //        m_listMoneyItem[i].gameObject.SetActive(false);
        //}
        //for (int i = 0; i < m_listTimeItem.Count; i++)
        //{
        //    if (m_listTimeItem[i] != null)
        //        m_listTimeItem[i].gameObject.SetActive(false);
        //}
    }

    [ContextMenu("resume")]
    public void ResumeWhenTrackingLost()
    {
        //for (int i = 0; i < m_listFaceBookItem.Count; i++)
        //{
        //    if(m_listFaceBookItem[i]!= null)
        //        m_listFaceBookItem[i].gameObject.SetActive(true);
        //}
        //for (int i = 0; i < m_listMoneyItem.Count; i++)
        //{
        //    if (m_listMoneyItem[i] != null)
        //        m_listMoneyItem[i].gameObject.SetActive(true);
        //}
        //for (int i = 0; i < m_listTimeItem.Count; i++)
        //{
        //    if (m_listTimeItem[i] != null)
        //        m_listTimeItem[i].gameObject.SetActive(true);
        //}
        for (int i = 0; i < m_listAllItem.Count; i++)
        {
            if (m_listAllItem[i] != null)
                m_listAllItem[i].gameObject.SetActive(true);
        }
    }

    public void RemoveObjectDie(ItemsType _type, string name)
    {
        //switch(_type)
        //{
        //    //case ItemsType.ItemGirl:
        //    //    Transform trf= m_listFaceBookItem.Find(x => x.name.Equals(name));
        //    //    if(trf)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf);
        //    //    }
        //    //    break;
        //    //case ItemsType.ItemMoney:
        //    //    Transform trf1 = m_listMoneyItem.Find(x => x.name.Equals(name));
        //    //    if (trf1)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf1);
        //    //    }
        //    //    break;
        //    //case ItemsType.ItemDeadline:
        //    //    Transform trf2 = m_listTimeItem.Find(x => x.name.Equals(name));
        //    //    if (trf2)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf2);
        //    //    }
        //    //    break;
        //}
        Transform trf = m_listAllItem.Find(x => x.name.Equals(name));
        if (trf)
        {
            m_listAllItem.Remove(trf);
        }
    }
    public void RemoveObjectDie(Transform _trf)
    {
        //switch(_type)
        //{
        //    //case ItemsType.ItemGirl:
        //    //    Transform trf= m_listFaceBookItem.Find(x => x.name.Equals(name));
        //    //    if(trf)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf);
        //    //    }
        //    //    break;
        //    //case ItemsType.ItemMoney:
        //    //    Transform trf1 = m_listMoneyItem.Find(x => x.name.Equals(name));
        //    //    if (trf1)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf1);
        //    //    }
        //    //    break;
        //    //case ItemsType.ItemDeadline:
        //    //    Transform trf2 = m_listTimeItem.Find(x => x.name.Equals(name));
        //    //    if (trf2)
        //    //    {
        //    //        m_listFaceBookItem.Remove(trf2);
        //    //    }
        //    //    break;
        //}
        //Transform trf = m_listAllItem.Find(x => x.name.Equals(name));
        if (_trf)
        {
            m_listAllItem.Remove(_trf);
        }
    }
}
