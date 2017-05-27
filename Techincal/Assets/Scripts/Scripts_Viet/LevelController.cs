using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelConfig
{
    public LevelConfig(int id, bool islock, int score, int cTime, int cFb, int cMoney)
    {
        this.id = id;
        this.m_isLock = islock;
        this.m_score = score;
        this.timeCount = cTime;
        this.facebookCount = cFb;
        this.moneyCount = cMoney;
    }
    public int id;
    public bool m_isLock = false;
    public int m_score;
    //
    public int timeCount; //10
    public int facebookCount;//19
    public int moneyCount;//20
}

public class LevelController : MonoBehaviour {
    public List<LevelConfig> m_listlevel = new List<LevelConfig>();
    public List<Button_Level> m_listButtonLevel = new List<Button_Level>();
    // tao list button
    void Start()
    {
        LevelConfig lv1 = new LevelConfig(1, false, 0, 10, 15, 20);
        LevelConfig lv2 = new LevelConfig(2, true, 0, 15, 20, 25);
        LevelConfig lv3 = new LevelConfig(3, true, 0, 20, 25, 30);
        LevelConfig lv4 = new LevelConfig(4, true, 0, 25, 30, 35);
        LevelConfig lv5 = new LevelConfig(5, true, 0, 30, 35, 40);
        m_listlevel.Add(lv1);
        m_listlevel.Add(lv2);
        m_listlevel.Add(lv3);
        m_listlevel.Add(lv4);
        m_listlevel.Add(lv5);
        m_listlevel.ForEach(delegate (LevelConfig it){
            Debug.Log(it.id);
            Button_Level bt = new Button_Level();
            bt.lvConfig = it;
            m_listButtonLevel.Add(bt);
        });
    }
}
