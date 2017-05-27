using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public enum itemType
{
    facebook,
    time,
    money
}

public class CoregameController : MonoSingleton<CoregameController> {
    public List<GameObject> m_listFB = new List<GameObject>();
}
