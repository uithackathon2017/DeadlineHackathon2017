using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Level : MonoBehaviour {

    public LevelConfig lvConfig;
    //
    public Image m_imgLockIcon;
    public Text m_id;

    public void Setup(LevelConfig _lvConfig)
    {
        this.lvConfig = _lvConfig;
        if(lvConfig != null)
        {
            if(m_imgLockIcon)
                m_imgLockIcon.gameObject.SetActive(this.lvConfig.m_isLock);
            if (m_id)
                m_id.text = "hoc ki " + this.lvConfig.id.ToString();
        }
    }
}
