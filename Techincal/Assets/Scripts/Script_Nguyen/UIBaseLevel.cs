using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBaseLevel : MonoBehaviour {

	// Use this for initializatio
    public int m_idOfLevel;
    public Text m_txtContent;
    [Header("config")]
    private bool m_isLock;
    public Image m_imgLock;

	    
    public bool IsLock
    {
        get
        {
            return m_isLock;
        }
        set
        {
            m_isLock = value;
            if (m_isLock && m_imgLock)
            {
                GetComponent<Button>().interactable = false;
                m_imgLock.gameObject.SetActive(true);
                //m_imgLock.sprite = SpriteManager.Instance.GetSpriteByTypeName(eSpriteName.LOCK);
            }
            else
            {
                GetComponent<Button>().interactable = true;
                m_imgLock.gameObject.SetActive(false);
            }
        }
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickHandle);
        m_txtContent.text = "LEVEL " + m_idOfLevel.ToString();
    }

    private void OnClickHandle()
    {
        //GameController.Instance.SetupWithLevel(this.m_idOfLevel - 1);
        //SpawnEnemy.Instance.m_ispawnedEnemy = false;
        //ScreenManager.Instance.ShowScreenByType(eScreenType.GAMEPLAY);
        //AudioManager.Instance.PlayOneShot(AudioType.UI_CLICK);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
