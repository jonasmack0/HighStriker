using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HeightScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    private float highScore = 0.0f;
    private bool highScoreReached = false;
    private Vector3 startPoint = new Vector3(-4.9f, 0f, 3f);
    private Vector3 endPointScore = new Vector3(-4.9f, 0.01f, 3f);
    private Vector3 endPointHighScore = new Vector3(-4.9f, 0.01f, 3.2f);
    private Vector3 startPointHighScore = new Vector3(-4.9f, 0f, 3.2f);



    public TMP_Text highScoreText;
    public LineRenderer ScoreDisplay;
    public LineRenderer HighScoreDisplay;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        ScoreDisplay.positionCount = 2;
        highScore = PlayerPrefs.GetFloat("HighScore", 0.01f);
        HighScoreDisplay.SetPosition(0, startPointHighScore);
    }

    void Update()
    {
        float height = rb.position.y - initialPosition.y;
        float displayHeight = height;
        float displayHighScoreHeight = highScore;

        if(height > 30.0f)
        {
            displayHeight = 30.0f;
        }

        if(displayHighScoreHeight > 30.0f)
        {
            displayHighScoreHeight = 30.0f;
        }

        if (height > highScore)
        {
            highScoreReached = true;
            highScore = height;
        }

        if (height < highScore && highScoreReached)
        {
            PlayerPrefs.SetFloat("HighScore", highScore);
            UpdateHighScoreText();
            Debug.Log("HighScore:" + highScore);
            highScoreReached = false;
        }

        startPoint = new Vector3(-4.9f, 0f, 3f);
        endPointScore = new Vector3(-4.9f, displayHeight / 10 + 0.001f, 3f);
        ScoreDisplay.SetPosition(0, startPoint);
        ScoreDisplay.SetPosition(1, endPointScore);
        endPointHighScore = new Vector3(-4.92f, displayHighScoreHeight / 10, 3.2f);
        HighScoreDisplay.SetPosition(1, endPointHighScore);
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "New Highscore! " + highScore + "m";
    }
}