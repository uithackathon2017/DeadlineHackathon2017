using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
    public UIBaseLevel[] m_arrayLevel;
    private int m_levelUnLockCount = 1;

    public int LevelUnLockCount
    {
        get { return m_levelUnLockCount; }
        set
        {
            m_levelUnLockCount = value;
            PlayerPrefs.SetInt(strLevelUnLockCount, m_levelUnLockCount);
        }
    }
    private const string strLevelUnLockCount = "unlockCount";
    // Use this for initialization
    void Awake()
    {
        SetupFullLock();
        LevelUnLockCount = PlayerPrefs.GetInt(strLevelUnLockCount);
    }

    private void SetupFullLock()
    {
        for (int i = 0; i < m_arrayLevel.Length; i++)
        {
            m_arrayLevel[i].IsLock = true;
        }
    }
    void OnEnable()
    {
        CheckLock();
    }
    [ContextMenu("test")]
    public void CheckLock()
    {
        if (LevelUnLockCount < 1)
        {
            LevelUnLockCount = 1;
        }
        for (int i = 0; i < LevelUnLockCount; i++)
        {
            m_arrayLevel[i].IsLock = false;
        }
    }
	
}
