using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int bestScore = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            // If there already was an instance of this object, destroy it to make this the only one
            Destroy(gameObject);
            return;
        }

        // Preserves this object instance when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        StartPlayingBackgroungMusic();
    }

    private void StartPlayingBackgroungMusic() {
        AudioManager.Instance.Play("BackgroundMusic");
    }

    public void Restart() {
        bestScore = Math.Max(ScoreManager.Instance.GetScore(), bestScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
