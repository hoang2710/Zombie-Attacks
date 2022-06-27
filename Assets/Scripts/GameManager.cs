using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameManager.GameState curState;
    public GameManager.GameState lastState;
    private bool wasPause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static event Action<GameState> OnGameStateChanged;

    private void Start()
    {
        ChangeGameState(GameState.Day);
    }
    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Day:
                OnGameStateDay();
                break;
            case GameState.Night:
                break;
            case GameState.Upgrade:
                break;
            case GameState.GameOver:
                break;
            case GameState.Pause:
                OnGameStatePause();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        lastState = curState;
        curState = state;

        OnGameStateChanged?.Invoke(state);
    }

    private void OnGameStatePause()
    {
        Time.timeScale = 0;
        wasPause = true;
    }

    public void OnGameStateDay()
    {
        if (wasPause)
        {
            Time.timeScale = 1;
            wasPause = false;
        }

    }

    public enum GameState
    {
        Day,
        Night,
        Upgrade,
        GameOver,
        Pause
    }
}
