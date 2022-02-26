using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }
}
