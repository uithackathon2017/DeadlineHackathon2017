using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum itemType
{
    facebook,
    time,
    money
}
[System.Serializable]
public class TempleteConfig
{
    public List<GameObject> m_listTemp;
    public int m_id;
}
public class CoregameController : MonoSingleton<CoregameController>
{
    public LevelConfig m_currentLevel;
    public LevelConfig m_startWithLevel;

    public Text m_txtTimeCountOfMission;
    public Text m_txtFacebookCountOfMission;
    public Text m_txtMoneyofCountOfMission;


    public int m_currentLevelID = 0;
    //
    //public List<TempleteConfig> m_listTempConfig = new List<TempleteConfig>();
    //public Dictionary<int, List<GameObject>> m_dicTemp = new Dictionary<int, List<GameObject>>();
    //public List<GameObject> m_listCurrentTemp = new List<GameObject>();


    public bool m_isplaying = false;
    public string strLevelID = "levelID";
    private void Awake()
    {
        //for (int i = 0; i < m_listTempConfig.Count; i++)
        //{
        //    m_dicTemp.Add(m_listTempConfig[i].m_id, m_listTempConfig[i].m_listTemp);
        //}
        m_currentLevelID = PlayerPrefs.GetInt("strLevelID");
        if(m_currentLevelID==0)
        {
            m_currentLevelID = 1;
            PlayerPrefs.SetInt(strLevelID,m_currentLevelID);
        }
    }

    private void Start()
    {
        //for (int i = 0; i < m_listTempConfig.Count; i++)
        //{
        //    List<GameObject> m_list = m_listTempConfig[i].m_listTemp;
        //    Debug.Log(",,,,"+m_list.Count);
        //    for (int j = 0; j < m_list.Count; j++)
        //    {
        //        //Debug.Log(",,,," + m_list[j].name);
        //        m_list[j].SetActive(false);

        //    }
        //}
    }

    //public List<GameObject> GetListTempFromDic(int id)
    //{
    //    if (m_dicTemp.ContainsKey(id))
    //    {
    //        return m_dicTemp[id];
    //    }
    //    return null;
    //}

    public bool m_isStart = false;
    public void Setup(LevelConfig _currentLevel)
    {
        m_currentLevel = _currentLevel;
        m_startWithLevel = _currentLevel;
        if (m_txtTimeCountOfMission)
            m_txtTimeCountOfMission.text = "Deadline :" + _currentLevel.timeCount.ToString();
        if (m_txtFacebookCountOfMission)
            m_txtFacebookCountOfMission.text = "Kiến thức :" + _currentLevel.facebookCount.ToString();
        if (m_txtMoneyofCountOfMission)
            m_txtMoneyofCountOfMission.text = "Học phí :" + _currentLevel.moneyCount.ToString();
        Timer = 0;
        SpawnManager.Instance.m_canSpawn = false;
    }


    public void Showtemplete3DByLevel()
    {
        //List<GameObject> listTemp = GetListTempFromDic(this.m_currentLevel.id);
        //Debug.Log(listTemp.Count);
        //for (int i = 0; i < listTemp.Count; i++)
        //{
        //    listTemp[i].SetActive(true);
        //}
        //for (int i = 0; i < m_listCurrentTemp.Count; i++)
        //{
        //    m_listCurrentTemp[i].SetActive(false);
        //}
        //m_listCurrentTemp.Clear();
        //m_listCurrentTemp = listTemp;
    }

    private int m_timer;

    public int m_timePlay = 60;

    public Text m_txttimer;

    public Image m_imgtimer;

    public int Timer
    {
        get
        {
            return m_timer;
        }

        set
        {
            m_timer = value;
            if(m_txttimer)
            {
                m_txttimer.text = value.ToString();
            }
            if(m_imgtimer)
            {
                m_imgtimer.fillAmount = (float)value / 60;
            }
        }
    }

    public void StartUpdateTimer()
    {
        StopCoroutine("UpdateTimer");
        StartCoroutine("UpdateTimer");
    }
    public void StopUpdateTimer()
    {
        StopCoroutine("UpdateTimer");
    }
    IEnumerator UpdateTimer()
    {
        while(Timer <= m_timePlay)
        {
            Timer += 1;
            yield return new WaitForSeconds(1);
        }
        DoGameEnd();
        yield break;
    }
    public void DoGameEnd()
    {
        this.m_isplaying = false;
        SpawnManager.Instance.m_canSpawn = false;
        ScreenManager.Instance.ShowScreenByType(eScreenType.GAME_END);
    }
    public void StartGame()
    {
        SpawnManager.Instance.m_canSpawn = true;
        m_isStart = true;
        m_isplaying = true;
        //StartUpdateTimer();
        //m_txtTimeCountOfMission.text = this.m_currentLevel.timeCount.ToString();
        //m_txtMoneyofCountOfMission.text = this.m_currentLevel.moneyCount.ToString();
        //m_txtFacebookCountOfMission.text = this.m_currentLevel.facebookCount.ToString();


    }

    // deadline
    public void setScoreTime(int score)
    {
        this.m_currentLevel.timeCount += score;

        if (m_txtTimeCountOfMission)
            m_txtTimeCountOfMission.text = "Deadline :" + m_currentLevel.timeCount.ToString();
        CheckGameover();
    }

    public void TryAgain()
    {
        this.m_currentLevel = m_startWithLevel;
        if (m_txtTimeCountOfMission)
            m_txtTimeCountOfMission.text = "Deadline :" + m_currentLevel.timeCount.ToString();
        if (m_txtFacebookCountOfMission)
            m_txtFacebookCountOfMission.text = "Girlfriend :" + m_currentLevel.facebookCount.ToString();
        if (m_txtMoneyofCountOfMission)
            m_txtMoneyofCountOfMission.text = "Money :" + m_currentLevel.moneyCount.ToString();
        Timer = 0;
        //SpawnManager.Instance.m_canSpawn = false;

    }
    // money
    public void setScoreFacebook(int score)
    {
        this.m_currentLevel.facebookCount += score;
        if (m_txtFacebookCountOfMission)
            m_txtFacebookCountOfMission.text = "Girlfriend :" + m_currentLevel.facebookCount.ToString();
        CheckGameover();

    }

    public void setScoreGirl(int score)
    {
        this.m_currentLevel.moneyCount += score;
        if (m_txtMoneyofCountOfMission)
            m_txtMoneyofCountOfMission.text = "Money :" + m_currentLevel.moneyCount.ToString();
        CheckGameover();
    }

    public void CheckGameover()
    {
        if (m_currentLevel.moneyCount <= 0 && m_currentLevel.timeCount <= 0 && m_currentLevel.facebookCount <= 0)
        {
            DoGameEnd();
            //m_currentLevelID++;
            //PlayerPrefs.SetInt(strLevelID, m_currentLevelID);
        }
    }

    public void SubScoreByType(ItemsType _type)
    {
        switch (_type)
        {
            case ItemsType.ItemDeadline:
                setScoreTime(-1);
                break;
            case ItemsType.ItemGirl:
                setScoreGirl(-1);
                break;
            case ItemsType.ItemMoney:
                setScoreFacebook(-1);
                break;
        }
    }
    public void addScoreByType(ItemsType _type)
    {
        switch (_type)
        {
            case ItemsType.ItemDeadline:
                setScoreTime(1);
                break;
            case ItemsType.ItemGirl:
                setScoreGirl(1);
                break;
            case ItemsType.ItemMoney:
                setScoreFacebook(1);
                break;
        }
    }
}