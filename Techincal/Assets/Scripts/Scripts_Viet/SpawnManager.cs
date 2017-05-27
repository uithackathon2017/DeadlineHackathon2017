using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoSingleton<SpawnManager> {
    public Transform m_positionSpawnItemFacebook;
    public Transform m_positionSpawnItemTime;
    public Transform m_positionSpawnItemMoney;

    public bool m_canSpawn = false;

    private float m_timeDelayOfFacebook = 6.0f;
    private float m_timeDelayOfMoney = 5.0f;
    private float m_timeDelayOfTime = 5.5f;

    public List<Transform> m_listFaceBookItem = new List<Transform>();
    public List<Transform> m_listTimeItem = new List<Transform>();
    public List<Transform> m_listMoneyItem = new List<Transform>();
    [ContextMenu("spawn all")]
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

        for(int i=0;i< m_listFaceBookItem.Count;i++)
        {
            ManagerObject.Instance.DespawnObject(m_listFaceBookItem[i].gameObject);
        }
        for (int i = 0; i < m_listTimeItem.Count; i++)
        {
            ManagerObject.Instance.DespawnObject(m_listTimeItem[i].gameObject);
        }
        for (int i = 0; i < m_listMoneyItem.Count; i++)
        {
            ManagerObject.Instance.DespawnObject(m_listMoneyItem[i].gameObject);
        }
    }

    [ContextMenu("spawn fb")]
    public void StartSpawnFacebook()
    {
        StopCoroutine("SpawnItemFaceBook");
        if (m_canSpawn)
            StartCoroutine("SpawnItemFaceBook");
    }

   

    //
    [ContextMenu("spawn time")]
    public void StartSpawnTime()
    {
        StopCoroutine("SpawnItemTime");
        if (m_canSpawn)
            StartCoroutine("SpawnItemTime");
    }
    //
    [ContextMenu("spawn money")]
    public void StartSpawnMoney()
    {
        StopCoroutine("SpawnItemMoney");
        if (m_canSpawn)
            StartCoroutine("SpawnItemMoney");
    }

    /// <summary>
    /// ............
    /// </summary>
    [ContextMenu("stop spawn time")]
    public void StopSpawnTime()
    {
        StopCoroutine("SpawnItemTime");

    }
    [ContextMenu("stop spawn fb")]
    public void StopSpawnFacebook()
    {
        StopCoroutine("SpawnItemFaceBook");

    }
    [ContextMenu("stop spawn fb")]
    public void StopSpawnMoney()
    {
        StopCoroutine("SpawnItemMoney");

    }
    //
    public IEnumerator SpawnItemFaceBook()
    {
        while(true)
        {
            Transform objFacebookprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_JUMP).transform;
            m_listFaceBookItem.Add(objFacebookprefabs);
            objFacebookprefabs.position = m_positionSpawnItemFacebook.position;
            yield return new WaitForSeconds(m_timeDelayOfFacebook);
        }
    }

    //
    public IEnumerator SpawnItemTime()
    {
        while (true)
        {
            Transform objTimeprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_NORMAL).transform;
            m_listTimeItem.Add(objTimeprefabs); // 
            objTimeprefabs.position = m_positionSpawnItemTime.position;
            yield return new WaitForSeconds(m_timeDelayOfTime);
        }
    }

    //
    public IEnumerator SpawnItemMoney()
    {
        while (true)
        {
            Transform objMoneyprefabs = ManagerObject.Instance.SpawnObjectByType(ObjectType.ITEM_STOP).transform;
            m_listMoneyItem.Add(objMoneyprefabs); // 
            objMoneyprefabs.position = m_positionSpawnItemMoney.position;
            yield return new WaitForSeconds(m_timeDelayOfMoney);
        }
    }

    [ContextMenu("pause")]
    public void PauseWhenTrackingLost()
    {
        for(int i=0;i<m_listFaceBookItem.Count;i++)
        {
            m_listFaceBookItem[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < m_listMoneyItem.Count; i++)
        {
            m_listMoneyItem[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < m_listTimeItem.Count; i++)
        {
            m_listTimeItem[i].gameObject.SetActive(false);
        }
    }

    [ContextMenu("resume")]
    public void ResumeWhenTrackingLost()
    {
        for (int i = 0; i < m_listFaceBookItem.Count; i++)
        {
            m_listFaceBookItem[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < m_listMoneyItem.Count; i++)
        {
            m_listMoneyItem[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < m_listTimeItem.Count; i++)
        {
            m_listTimeItem[i].gameObject.SetActive(true);
        }
    }
}
