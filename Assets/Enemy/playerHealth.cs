using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int _playerHealth = 100;

    public void takeDamage(int damage)
    {
        if(_playerHealth > 0)
        _playerHealth -= damage;
        
        if(_playerHealth <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
