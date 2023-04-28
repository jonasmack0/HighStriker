using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public TextMesh textMesh;
    public Transform cameraTransform;
    public string prefixText;

    private void Update()
    {
        // Update the text value
        textMesh.text = prefixText + GetValueToDisplay().ToString();

        // Make the text face the camera
        transform.LookAt(transform.position + cameraTransform.forward);
    }

        private void UpdateHighScoreText()
    {
       // highScoreText.text = "High Score: " + highScore.ToString();
    }

    private int GetValueToDisplay()
    {
        // Replace this with your own logic to get the value you want to display
        return Random.Range(0, 100);
    }
}

