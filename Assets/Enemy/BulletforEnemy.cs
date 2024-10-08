using UnityEngine;

public class BulletForEnemy : MonoBehaviour
{
    public int giveDamage = 10;
    private playerHealth player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<playerHealth>();
            player.takeDamage(giveDamage);
        }
        else
        {
            return;
        }
    }
}

