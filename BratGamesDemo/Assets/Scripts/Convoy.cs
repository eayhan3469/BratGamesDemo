using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convoy : MonoBehaviour
{
    public static Convoy Instance;

    [Header("Guards")]
    public List<GameObject> LeftGuards;
    public List<GameObject> RightGuards;
    public List<GameObject> FrontGuards;

    [Header("Convoy Properties")]
    [SerializeField]
    private float ConvoySpeed = 1.0f;

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("'Convoy' must be one");
        else
            Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.HasGameStart)
        {
            transform.Translate(Vector3.forward * ConvoySpeed * Time.deltaTime);
        }
    }
}
