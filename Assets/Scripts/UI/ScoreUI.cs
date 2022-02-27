using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Header("Playing state UI")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text speedMultiplierText;

    [Header("Game Over state UI")]
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text bestScoreText;

    private float lastPoints = 0;
    private float addedPoints = 0;
    private Coroutine pointsCoroutine;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();
        finalScoreText.text = ScoreManager.Instance.GetScore().ToString();
        bestScoreText.text = BestScoreManager.Instance.GetBestScore().ToString();

        float newPoints = ScoreManager.Instance.GetPoints();
        if (newPoints - lastPoints > 0) {
            AddPointsText(newPoints - lastPoints);
        }
        lastPoints = newPoints;

        if (addedPoints == 0) {
            pointsText.text = "";
        } else {
            pointsText.text = addedPoints.ToString();
        }

        speedMultiplierText.text = (ClonesManager.Instance.Count() + 1).ToString();
    }

    public void AddPointsText(float points) {
        if (pointsCoroutine != null) {
            // Stop any previous one called
            StopCoroutine(pointsCoroutine);
        }
        pointsCoroutine = StartCoroutine(AddPointsCoroutine(points));
    }

    IEnumerator AddPointsCoroutine(float points) {
        addedPoints += points;
        yield return new WaitForSeconds(2f);
        addedPoints = 0;
        yield return null;
    }
}
