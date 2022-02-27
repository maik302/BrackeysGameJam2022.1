using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _playingMenu;
    [SerializeField] private GameObject _gameOverMenu;

    // Update is called once per frame
    void Update() {
        switch (GameManager.Instance.GetCurrentGameState()) {
            case GameManager.GameState.PAUSE:
                EnablePauseUI();
                break;
            case GameManager.GameState.PLAYING:
                EnablePlayingUI();
                break;
            case GameManager.GameState.GAME_OVER:
                EnableGameOverUI();
                break;
        }
    }

    void EnablePauseUI() {
        _pauseMenu.SetActive(true);
        _playingMenu.SetActive(true);
        _gameOverMenu.SetActive(false);
    }

    void EnableGameOverUI() {
        _pauseMenu.SetActive(false);
        _playingMenu.SetActive(false);
        _gameOverMenu.SetActive(true);
    }

    void EnablePlayingUI() {
        _pauseMenu.SetActive(false);
        _playingMenu.SetActive(true);
        _gameOverMenu.SetActive(false);
    }
}
