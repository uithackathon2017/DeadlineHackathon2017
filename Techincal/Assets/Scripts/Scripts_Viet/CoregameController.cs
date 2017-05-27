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

public class CoregameController : MonoSingleton<CoregameController> {
    public LevelConfig m_currentLevel;

    public Text m_txtTimeCountOfMission;
    public Text m_txtFacebookCountOfMission;
    public Text m_txtMoneyofCountOfMission;

    //
    public bool m_isStart = false;
    public void Setup(LevelConfig _currentLevel)
    {
        m_currentLevel = _currentLevel;
        if (m_txtTimeCountOfMission)
            m_txtTimeCountOfMission.text = _currentLevel.timeCount.ToString();
        if (m_txtFacebookCountOfMission)
            m_txtFacebookCountOfMission.text = _currentLevel.facebookCount.ToString();
        if (m_txtMoneyofCountOfMission)
            m_txtMoneyofCountOfMission.text = _currentLevel.moneyCount.ToString();

        SpawnManager.Instance.m_canSpawn = false;
    }

    public void StartGame()
    {
        SpawnManager.Instance.m_canSpawn = true;
    }

}
