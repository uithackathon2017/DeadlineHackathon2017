using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelConfig
{
    public int id;
    public bool m_isLock = false;
    public int m_score;
    //
    public int timeCount; //10
    public int facebookCount;//19
    public int moneyCount;//20
}

public class LevelManager : MonoBehaviour {
    public List<LevelConfig> m_listlevel = new List<LevelConfig>();
    // tao list button
}
