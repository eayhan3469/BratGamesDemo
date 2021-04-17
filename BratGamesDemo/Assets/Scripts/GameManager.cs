using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Text countDownText;

    [SerializeField]
    private float countDown;

    public bool HasGameStart { get; internal set; }
    public bool HasGameOver { get; internal set; }

    void Awake()
    {
        if (Instance != null)
            Debug.LogError("'GameManager' must be one");
        else
            Instance = this;
    }

    private async void OnStartAsync()
    {
        countDownText.gameObject.SetActive(true);
        HasGameStart = false;

        while (countDown > 0.25f)
            await Task.Yield();

        HasGameStart = true;
        countDownText.gameObject.SetActive(false);
    }

    private void Start()
    {
        OnStartAsync();
    }

    private void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;

            if (countDown < 0.5f)
                countDownText.text = String.Format("START");
            else
                countDownText.text = countDown.ToString("0");
        }

        if (HasGameOver)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
