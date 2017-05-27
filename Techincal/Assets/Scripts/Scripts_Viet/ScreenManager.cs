using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public enum eScreenType
{
    START_SCREEN,
    LEVEL_SCREEN,
    CORE_GAME,
    GAME_END
}

public enum ePopupType
{
    
}

[System.Serializable]
public class MyScreen
{
    public eScreenType m_screenType;
    public GameObject m_objectScreen;
}

[System.Serializable]
public class MyPopup
{
    public ePopupType m_popupType;
    public GameObject m_objectPopup;
}
public class ScreenManager : MonoSingleton<ScreenManager>
{
    public MyScreen[] m_arrayMyScreen;
    //public MyPopup[] m_arrayMyPopup;
    public Dictionary<eScreenType, GameObject> m_dicScreen = new Dictionary<eScreenType, GameObject>();
    //public Dictionary<ePopupType, GameObject> m_dicPopup = new Dictionary<ePopupType, GameObject>();
    private eScreenType m_currentScreen;
    //private ePopupType m_currentPopup;
    private Stack m_myStackOfScreen = new Stack();
    public eScreenType CurrentScreen
    {
        get { return m_currentScreen; }
        set { m_currentScreen = value; }
    }

    // config
    //public Button m_buttonBack;
    //public Text m_txtOfButtonBack;
    //public Image m_imgBackground;
    // Use this for initialization
    void Awake()
    {
        InitDictionary();
    }

    void Start()
    {
        ShowScreenByType(eScreenType.START_SCREEN);
    }

    private void InitDictionary()
    {
        if (m_arrayMyScreen.Length > 0)
        {
            for (int i = 0; i < m_arrayMyScreen.Length; i++)
            {
                m_dicScreen.Add(m_arrayMyScreen[i].m_screenType, m_arrayMyScreen[i].m_objectScreen);
                m_arrayMyScreen[i].m_objectScreen.SetActive(false);
            }
        }
    }

    void Update()
    {
#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(CurrentScreen == eScreenType.START_SCREEN)
            {
                Application.Quit();
            }
            else
            {
                ShowScreenPrev();
            }
        }
#endif
    }

    #region SCREEN_MANAGER
    private GameObject GetScreenByType(eScreenType type)
    {
        if (m_dicScreen.ContainsKey(type))
        {
            return m_dicScreen[type];
        }
#if UNITY_EDITOR
        //Debug.Log("ko get duoc man hinh nay!");
#endif
        return null;
    }


    public GameObject ShowScreenByType(eScreenType _type)
    {
        HideScreenByType(CurrentScreen);
        m_myStackOfScreen.Push(CurrentScreen);

        GameObject objScreen = GetScreenByType(_type);

        if (objScreen)
        {
            objScreen.SetActive(true);
        }
        CurrentScreen = _type;
        return objScreen;
    }


    public void HideCurrentScreen()
    {
        if (m_myStackOfScreen.Count > 0)
        {
            eScreenType currentScreen = (eScreenType)m_myStackOfScreen.Pop();
            HideScreenByType(currentScreen);
        }
    }

    public void ShowScreenPrev()
    {
        eScreenType screenCurrent = (eScreenType)m_myStackOfScreen.Pop();
        
        HideScreenByType(CurrentScreen);
        CurrentScreen = screenCurrent;
        GameObject screenPrev = GetScreenByType(screenCurrent);
        screenPrev.SetActive(true);
    }

    private void CallBackCloseWindow()
    {
        eScreenType screenPrev = (eScreenType)m_myStackOfScreen.Pop();
        ShowScreenByType(screenPrev);
    }

    public void HideScreenByType(eScreenType type)
    {
        GameObject objScreen = GetScreenByType(type);

        if (objScreen)
        {
            objScreen.SetActive(false);
        }
    }

    #endregion SCREEN_MANAGER

    #region POPUP..........................
    //public void HideCurrentPopup()
    //{
    //    if(CurrentPopup == ePopupType.NONE)
    //    {
    //        return;
    //    }
    //    GameObject objScreenPopup = GetPopupByType(CurrentPopup);
    //    if (objScreenPopup)
    //    {
    //        m_generalScreen.gameObject.SetActive(false);
    //        objScreenPopup.SetActive(false);
    //        CurrentPopup = ePopupType.NONE;
    //    }
    //    //ShowScreenByType(CurrentScreen);
    //    ShowCurrentScreen();
    //}
    //public void ShowPopupScreen(ePopupType _type)
    //{
    //    GameObject objScreenPopup = GetPopupByType(_type);
    //    HideCurrentPopup();
    //    HideScreenByType(CurrentScreen);
    //    if(_type == ePopupType.OPTION || _type == ePopupType.SETTING )
    //    {
    //        m_generalScreen.gameObject.SetActive(true);
    //        m_generalScreen.SetUp(_type);
    //    }
    //    if (objScreenPopup)
    //    {
    //        objScreenPopup.SetActive(true);
    //    }
    //    CurrentPopup = _type; 
    //}

    //public void DestroyPopupByType(ePopupType _type)
    //{
    //    Destroy(GetPopupByType(_type));
    //    int index = GetIndexOfPopup(_type);
    //    m_arrayMyPopup = RemoveAt(m_arrayMyPopup, index);
    //}

    //private int GetIndexOfPopup(ePopupType _type)
    //{
    //    for(int i=0;i<m_arrayMyPopup.Length;i++)
    //    {
    //        if (m_arrayMyPopup[i].m_popupType == _type)
    //        {
    //            return i;
    //        }
    //    }
    //    return 0;
    //}
    public T[] RemoveAt<T>(T[] oArray, int idx)
    {
        T[] nArray = new T[oArray.Length - 1];
        for (int i = 0; i < nArray.Length; ++i)
        {
            nArray[i] = (i < idx) ? oArray[i] : oArray[i + 1];
        }
        return nArray;
    }
    #endregion...
}
