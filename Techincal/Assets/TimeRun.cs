using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRun : MonoBehaviour {
    public Image img;
    public float Smooth = 1f;
    // Use this for initialization
    void Start()
    {
        //img.fillAmount = 0;
        Debug.Log("Time Start" + Time.realtimeSinceStartup);
        StartUpdateTimer();
        img.fillAmount = 1;
    }

    private float m_timer;

    public float m_timePlay = 3.0f;

    //public Text m_txttimer;

    //public Image m_imgtimer;

    public float Timer
    {
        get
        {
            return m_timer;
        }

        set
        {
            m_timer = value;
            img.fillAmount = 1 -( (float)value / m_timePlay);
            Debug.Log(value);
        }
    }

    public void StartUpdateTimer()
    {
        //StopCoroutine("UpdateTimer");
        StartCoroutine("UpdateTimer");
    }
    public void StopUpdateTimer()
    {
        StopCoroutine("UpdateTimer");
    }
    IEnumerator UpdateTimer()
    {
        while (Timer <= m_timePlay)
        {
            Timer += Smooth;
            //Debug.Log(Timer);
            yield return new WaitForSeconds(Smooth);
        }
        //DoGameEnd();
        //yield break;
    }
    public void DoGameEnd() {
    }
}
