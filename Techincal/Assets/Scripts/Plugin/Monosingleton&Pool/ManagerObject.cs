﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

public enum ObjectType
{
    OBJ_BULLET,
    ITEM_NORMAL,
    ITEM_STOP,
    //ITEM_SINCE_COS,
    BUTTON_LEVEL,
    ITEM_JUMP,
        
}

[System.Serializable]
public class ObjectConfig
{
    public ObjectType _type;
    public GameObject _object;
}

public enum PoolName
{
    pool
}

public class ManagerObject : MonoSingleton<ManagerObject>
{
    public List<ObjectConfig> listObjectConfig;
    public Dictionary<ObjectType, GameObject> dicListObject;

    private const string m_poolname = "pool";
    void Awake()
    {
        InitDictionary();
    }

    public void InitDictionary()
    {
        dicListObject = new Dictionary<ObjectType, GameObject>();

        foreach (ObjectConfig var in listObjectConfig)
        {
            dicListObject.Add(var._type, var._object);
        }
    }

    public GameObject GetObjectByType(ObjectType type)
    {
        if (dicListObject.ContainsKey(type))
        {
            return dicListObject[type];
        }
#if UNITY_EDITOR
        Debug.Log("khong co trong list !!");
#endif
        return null;
    }

    public GameObject SpawnObjectByType(ObjectType type)
    {
        GameObject objSpawn = GetObjectByType(type);
        SpawnPool pool = PoolManager.Pools[m_poolname];
        if (pool != null && objSpawn != null)
        {
            return pool.Spawn(objSpawn).gameObject;
        }
#if UNITY_EDITOR
        Debug.Log("khong spawn duoc!");
#endif
        return null;
    }

    public GameObject SpawnObjectByType(ObjectType type, Transform parent,PoolName poolName)
    {
        GameObject objSpawn = GetObjectByType(type);
        SpawnPool pool = PoolManager.Pools[poolName.ToString()];
        if (pool != null && objSpawn != null)
        {
            return pool.Spawn(objSpawn, parent).gameObject;
        }
#if UNITY_EDITOR
        Debug.Log("khong spawn duoc!");
#endif
        return null;
    }

    public void DespawnObject(GameObject obj)
    {
        if (PoolManager.Pools.ContainsKey(m_poolname))
        {
            SpawnPool pool = PoolManager.Pools["pool"];
            //Debug.Log(poolName.ToString());
            if (pool.IsSpawned(obj.transform))
            {
                Debug.Log("desapw");
                pool.Despawn(obj.transform);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(m_poolname + "khong co trong pool");
#endif
        }
    }

    public void DespawnObjectAfter(GameObject obj, PoolName poolName, float time)
    {
        if (PoolManager.Pools.ContainsKey(poolName.ToString()))
        {
            SpawnPool pool = PoolManager.Pools[poolName.ToString()];
            if (pool.IsSpawned(obj.transform))
            {
                pool.Despawn(obj.transform,time);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(poolName + "khong co trong pool");
#endif
        }
    }

    public void DespawnAllObject(string poolName)
    {
        if (PoolManager.Pools.ContainsKey(poolName))
        {
            SpawnPool pool = PoolManager.Pools[poolName];
            pool.DespawnAll();
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(poolName + "khong co trong pool");
#endif
        }
    }
}
