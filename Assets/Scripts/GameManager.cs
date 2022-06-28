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
        ChangeGameState(GameState.StartMenu);
    }
    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.StartMenu:
            OnGameStateStartMenu();
                break;
            case GameState.Day:
                OnGameStateDay();
                break;
            case GameState.Night:
                OnGameStateNight();
                break;
            case GameState.Upgrade:
                OnGameStateUpgrade();
                break;
            case GameState.GameOver:
                OnGameStateGameOver();
                break;
            case GameState.Pause:
                OnGameStatePause();
                break;
                case GameState.Resume:
                OnGameStateResume();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        OnGameStateChanged?.Invoke(state);
    }

    private void OnGameStateStartMenu(){
        
    }
    private void OnGameStateDay()
    {

    }
    private void OnGameStateNight()
    {

    }
    private void OnGameStateUpgrade()
    {
        
    }
    private void OnGameStateGameOver()
    {
        Time.timeScale = 0;
    }
    private void OnGameStatePause()
    {
        Time.timeScale = 0;
    }
    private void OnGameStateResume(){
        Time.timeScale = 1;
    }

    public enum GameState
    {
        StartMenu,
        Day,
        Night,
        Upgrade,
        GameOver,
        Pause,
        Resume
    }
}
