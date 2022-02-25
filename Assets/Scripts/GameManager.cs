using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    [SerializeField] int score;

    private void Awake() {
        inst = this;
    }

    private void Start() {
        StartPlayingBackgroungMusic();
    }

    private void StartPlayingBackgroungMusic() {
        AudioManager.Instance.Play("BackgroundMusic");
    }

    public void AddPoints(int points) {
        score += points;
    }
}
