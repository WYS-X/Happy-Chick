using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI TextScore;
    private int score = 0;

    public const int GameDuration = 120;
    float timer;
    public TextMeshProUGUI TextTimer;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        score = 0;
        timer = GameDuration;
        UpdateUI();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        UpdateUI();
    }
    public void AddScore(int amount = 1)
    {
        score += amount;
        if (TextScore != null)
            TextScore.text = score.ToString();
    }

    void UpdateUI()
    {
        if (TextScore != null)
        {
            TextScore.text = score.ToString();
        }            
        if (TextTimer != null)
        {
            var t = Mathf.CeilToInt(timer);
            TextTimer.text = t.ToString();
        }
            
    }
}
