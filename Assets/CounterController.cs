using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField] private Transform m_cameraTransform;
    [SerializeField] private int m_initialCount = 0;
    [SerializeField] private TextMesh m_messageText;
    public int m_totalCans = 6;

    private int m_count;

    void Start()
    {
        m_count = m_initialCount;
        UpdateCounterText();
    }

    void Update()
    {
        transform.LookAt(transform.position + m_cameraTransform.forward);

        if (m_count >= m_totalCans)
        {
            m_messageText.text = "Success!";
            Invoke("ResetGameState", 5.0f);
        }
    }

    public void IncrementCount()
    {
        m_count++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        textMesh.text = "Cans fallen: " + m_count;
    }

    private void ResetGameState()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}