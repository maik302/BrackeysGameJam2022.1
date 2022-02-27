using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start() {
        AudioManager.Instance.Stop("BackgroundMusic");
    }

    public void PlayGame() {
        SceneManager.LoadScene("Runner");
    }
}
