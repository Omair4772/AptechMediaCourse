using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform playerTransform;  // Assign your player GameObject's transform in the inspector.

    // Key names for storing position in PlayerPrefs
    private string playerPosXKey = "PlayerPosX";
    private string playerPosYKey = "PlayerPosY";
    private string playerPosZKey = "PlayerPosZ";

    // This method is called when the player enters the special point
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Assuming your player has the tag "Player"
        {
            SavePlayerPosition();
        }
    }

    // Save player's position
    public void SavePlayerPosition()
    {
        Vector3 playerPosition = playerTransform.position;

        // Store the position in PlayerPrefs
        PlayerPrefs.SetFloat(playerPosXKey, playerPosition.x);
        PlayerPrefs.SetFloat(playerPosYKey, playerPosition.y);
        PlayerPrefs.SetFloat(playerPosZKey, playerPosition.z);

        // Ensure changes are saved
        PlayerPrefs.Save();

        Debug.Log("Player position saved at: " + playerPosition);
    }

    // Load the player's saved position when the game starts or restarts
    public void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey(playerPosXKey) && PlayerPrefs.HasKey(playerPosYKey) && PlayerPrefs.HasKey(playerPosZKey))
        {
            float x = PlayerPrefs.GetFloat(playerPosXKey);
            float y = PlayerPrefs.GetFloat(playerPosYKey);
            float z = PlayerPrefs.GetFloat(playerPosZKey);

            Vector3 savedPosition = new Vector3(x, y, z);
            playerTransform.position = savedPosition;

            Debug.Log("Player position loaded: " + savedPosition);
        }
        else
        {
            Debug.Log("No saved position found.");
        }
    }

    // You can call this in the Start() method or wherever you want to load the position.
    private void Start()
    {
        LoadPlayerPosition();
    }
}
