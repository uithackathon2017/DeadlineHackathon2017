using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

	public void onClickPlay()
    {
        ScreenManager.Instance.ShowScreenByType(eScreenType.LEVEL_SCREEN);

    }
}
