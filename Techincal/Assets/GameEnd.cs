using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {
    public void OnClickReplay()
    {
        CoregameController.Instance.TryAgain();
        ScreenManager.Instance.ShowScreenByType(eScreenType.CORE_GAME);
    }
}
