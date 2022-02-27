using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text pointsText;

    private float lastPoints = 0;
    private float addedPoints = 0;
    private Coroutine pointsCoroutine;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();

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
