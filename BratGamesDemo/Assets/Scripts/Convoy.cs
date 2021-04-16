using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convoy : MonoBehaviour
{
    public static Convoy Instance;

    public List<GameObject> LeftGuards;
    public List<GameObject> RightGuards;
    public List<GameObject> FrontGuards;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("'Convoy' must be one");
        else
            Instance = this;
    }
}
