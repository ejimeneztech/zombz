using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f;  // Starting time in seconds (2 minutes)
    public TextMeshProUGUI timerText;

    private bool timerRunning = true;
    private Color defaultColor;

    void Start()
    {
        // Store the initial color of the timer text
        if (timerText != null)
        {
            defaultColor = timerText.color;
        }
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            // Ensure time doesn't go below 0
            timeRemaining = Mathf.Max(timeRemaining, 0);

            // Convert time to minutes and seconds
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            // Change color to red if less than 10 seconds remain
            if (timeRemaining <= 11 && timerText != null)
            {
                timerText.color = Color.red;
            }
            else if (timeRemaining > 10 && timerText != null)
            {
                timerText.color = defaultColor;
            }

            // Display time in MM:SS format
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                Debug.Log(timerText.text);
            }
        }
        else if (timeRemaining <= 0 && timerRunning)
        {
            timerRunning = false;  // Stop the timer
            if (timerText != null)
            {
                timerText.text = "00:00";  // Ensure it displays 00:00 when time is up
            }
            Debug.Log("Time's up!");  // Optional: Add actions when time runs out
        }
    }
}
