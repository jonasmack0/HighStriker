using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHighscoreButtonController : MonoBehaviour
{
    public void HighScoreReset()
    {
        PlayerPrefs.SetFloat("HighScore", 0.01f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
