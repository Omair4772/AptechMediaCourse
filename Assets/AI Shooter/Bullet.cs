using UnityEngine;

public class Bullet : MonoBehaviour
{
    cubeAiSystemRed   RedCube;
    cubeAiSystemBlue  BlueCube;
    cubeAiSystemGreen GreenCube;
    public int giveDamage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            return;
        }
    }
}

