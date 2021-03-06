﻿using System.Collections;
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
    public Transform m_trfContent;
   // public RectTransform m_rectrfContent;

    public float m_sizeContentX = 300.0f;
    public float m_spaceContentX = 50.0f;

    public List<Color> m_listColor = new List<Color>();

    // tao list button
    void OnEnable()
    {
        //LevelConfig lv1 = new LevelConfig(1, false, 0, 10, 15, 20);
        //LevelConfig lv2 = new LevelConfig(2, true, 0, 15, 20, 25);
        //LevelConfig lv3 = new LevelConfig(3, true, 0, 20, 25, 30);
        //LevelConfig lv4 = new LevelConfig(4, true, 0, 25, 30, 35);
        //LevelConfig lv5 = new LevelConfig(5, true, 0, 30, 35, 40);
        //m_listlevel.Add(lv1);
        //m_listlevel.Add(lv2);
        //m_listlevel.Add(lv3);
        //m_listlevel.Add(lv4);
        //m_listlevel.Add(lv5);
        int i = 0;
        m_listlevel.ForEach(delegate (LevelConfig it){
            //Debug.Log(it.id);
            GameObject buttonLevel = ManagerObject.Instance.SpawnObjectByType(ObjectType.BUTTON_LEVEL);
            if(m_trfContent && buttonLevel)
            {
                buttonLevel.transform.SetParent(m_trfContent);
                buttonLevel.transform.localScale = Vector3.one;
                Button_Level bt = buttonLevel.GetComponent<Button_Level>();
                
                bt.Setup(it);

                //
                buttonLevel.GetComponent<Image>().color = m_listColor[i];
                m_listButtonLevel.Add(bt);
                i++;
            }
        });

        //Debug.Log("CoregameController.Instance.m_currentLevelID"+CoregameController.Instance.m_currentLevelID);
        //for(int k=0;k< CoregameController.Instance.m_currentLevelID;i++)
        //{
        //    LevelConfig bt = m_listlevel[i];
        //    bt.m_isLock = true;
        //    m_listButtonLevel[i].Setup (bt);
        //}
        ////if(m_rectrfContent)
        //{
        //    Vector2 size = new Vector2(m_sizeContentX* m_listlevel.Count-m_spaceContentX* (m_listlevel.Count-2), 0);
        //    m_rectrfContent.sizeDelta = size;
        //}
    }
}
