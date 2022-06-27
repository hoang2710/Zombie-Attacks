using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
                break;
            case GameState.Night:
                break;
            case GameState.Upgrade:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        OnGameStateChanged?.Invoke(state);
    }

    public enum GameState
    {
        Day,
        Night,
        Upgrade,
        GameOver
    }
}
