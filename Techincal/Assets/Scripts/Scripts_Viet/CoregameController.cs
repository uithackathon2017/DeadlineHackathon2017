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

    public Text m_txtTimeCountOfMission;
    public Text m_txtFacebookCountOfMission;
    public Text m_txtMoneyofCountOfMission;

    //
    //public List<TempleteConfig> m_listTempConfig = new List<TempleteConfig>();
    //public Dictionary<int, List<GameObject>> m_dicTemp = new Dictionary<int, List<GameObject>>();
    //public List<GameObject> m_listCurrentTemp = new List<GameObject>();


    public bool m_isplaying = false;

    private void Awake()
    {
        //for (int i = 0; i < m_listTempConfig.Count; i++)
        //{
        //    m_dicTemp.Add(m_listTempConfig[i].m_id, m_listTempConfig[i].m_listTemp);
        //}
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
        if (m_txtTimeCountOfMission)
            m_txtTimeCountOfMission.text = "Deadline :" + _currentLevel.timeCount.ToString();
        if (m_txtFacebookCountOfMission)
            m_txtFacebookCountOfMission.text = "Girlfriend :" + _currentLevel.facebookCount.ToString();
        if (m_txtMoneyofCountOfMission)
            m_txtMoneyofCountOfMission.text = "Money :" + _currentLevel.moneyCount.ToString();

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

    public void StartGame()
    {
        SpawnManager.Instance.m_canSpawn = true;
        m_isStart = true;
        m_isplaying = true;
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
        if (m_currentLevel.moneyCount == 0 && m_currentLevel.timeCount == 0 && m_currentLevel.facebookCount == 0)
        {
            Debug.Log("gameover");
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