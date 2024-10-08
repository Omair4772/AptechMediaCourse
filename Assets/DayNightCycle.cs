using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // This variable determines how many real-time seconds it takes for a full day to pass
    [Tooltip("The duration of a full day in seconds.")]
    public float dayDurationInSeconds = 120f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the amount to rotate based on time passed and the duration of a full day
        float rotationThisFrame = (360f / dayDurationInSeconds) * Time.deltaTime;

        // Rotate the light around the X-axis to simulate the sun moving across the sky
        transform.Rotate(new Vector3(rotationThisFrame, 0f, 0f));
    }
}
