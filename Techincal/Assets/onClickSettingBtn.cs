using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class onClickSettingBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void clickSetting()
    {
        var panel = GameObject.Find("Canvas/Coregameplay/Setting_panel");
        panel.SetActive(!panel.active);
    }

    public void clickAbout()
    {
        var panel = GameObject.Find("Canvas/Coregameplay/AboutInfor");
        panel.SetActive(!panel.active);
        var panel1 = GameObject.Find("Canvas/Coregameplay/Setting_panel");
        panel1.SetActive(false);
    }

    public void clickResume()
    {
        var panel = GameObject.Find("Canvas/Coregameplay/Setting_panel");
        panel.SetActive(false);
    }

    public void clickExit()
    {
        Application.Quit();
    }
	
    public void clikBackinAboutInfor()
    {
        var panel = GameObject.Find("Canvas/Coregameplay/AboutInfor");
        panel.SetActive(!panel.active);
        var panel1 = GameObject.Find("Canvas/Coregameplay/Setting_panel");
        panel1.SetActive(true);
    }
}
