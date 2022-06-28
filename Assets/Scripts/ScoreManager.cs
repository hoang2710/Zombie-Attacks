using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private static int playerScore = 0;
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerScore = 0;
        UIManager.Instance.UpDateScoreText(playerScore);
    }
    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {

    }

    public void GetScore(int score)
    {
        playerScore += score;
        UIManager.Instance.UpDateScoreText(playerScore);
    }
}
