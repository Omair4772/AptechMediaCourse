using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int minutes;
    public float seconds = 60;
    public TextMeshProUGUI remaininShowTime;

    public GameObject winConvax;

    public WinDecider winDecider;
    public TextMeshProUGUI WinnerIs;

    private bool timerIsRunning = false;

    void Start()
    {
        Time.timeScale = 1f;
        // Start the timer when the game starts
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (minutes >= 0 && seconds >= 0)
            {
                seconds -= Time.deltaTime; // Reduce time by the elapsed time since the last frame
                DisplayTime(seconds); // Display the timer in minutes and seconds
            }
            if (minutes <= 0 && seconds <= 0)
            {
                seconds = 0;
                timerIsRunning = false;
                winConvax.SetActive(true);
                Debug.Log("Time has run out!");
                Time.timeScale = 0f;
                WinnerIs.text = winDecider.winCubeIs + "";
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // This will display minutes and seconds format (MM:SS)
        timeToDisplay += 1; // Adding 1 to display 0 seconds instead of negative time when timer hits 0
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Calculate minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Calculate seconds

        // If you're using UI Text
        if (remaininShowTime != null)
        {
            remaininShowTime.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format and display the timer
        }

        // Or use Debug.Log to print the time to the console
        Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
