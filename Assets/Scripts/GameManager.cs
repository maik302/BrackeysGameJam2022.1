using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState {
        PLAYING,
        PAUSE,
        GAME_OVER
    };

    GameState _currentGameState;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Start() {
        _currentGameState = GameState.PLAYING;
        StartPlayingBackgroungMusic();
    }

    private void StartPlayingBackgroungMusic() {
        AudioManager.Instance.Play("BackgroundMusic");
    }

    public void Restart() {
        BestScoreManager.Instance.SaveBestScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameState GetCurrentGameState() {
        return _currentGameState;
    }

    public void SetGameState(GameState gameState) {
        _currentGameState = gameState;
    }
}
