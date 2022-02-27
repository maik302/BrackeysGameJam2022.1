using System;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;
    private int bestScore = 0;

    void Awake() {
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


    public void SaveBestScore() {
        bestScore = Math.Max(ScoreManager.Instance.GetScore(), bestScore);
    }

    public int GetBestScore() {
        return bestScore;
    }

}
