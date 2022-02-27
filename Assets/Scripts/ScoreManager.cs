using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Transform playerTransform;
    private int points = 0;

    private bool timerIsRunning = false;
    private float secondsPassed;

    [SerializeField] private float distanceMultiplier = 0.2f;
    [SerializeField] private float pointsMultiplier = 5f;
    [SerializeField] private float timePenaltyRoot = 1.85f;
    [SerializeField] private float timeDistanceDivider = 10f;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        secondsPassed = 0;
    }

    void Update() {
        timerIsRunning = GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PLAYING;
    }

    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            secondsPassed += Time.fixedDeltaTime;
        }
        // Debug.Log(GetDistance() + " + " + GetPoints() + " - " + GetTimePenalty() + " = " + GetScore());
    }

    public void AddPoints(int pointsToAdd) {
        points += pointsToAdd;
    }

    float GetDistance()
    {
        return playerTransform.position.z * distanceMultiplier;
    }

    public float GetPoints() {
        return points * pointsMultiplier;
    }

    double GetTimePenalty() {
        return Math.Pow(GetDistance() * secondsPassed/timeDistanceDivider, 1/timePenaltyRoot);
    }

    public int GetScore() {
        return (int) Math.Floor(GetDistance() + GetPoints() - GetTimePenalty());
    }
}
