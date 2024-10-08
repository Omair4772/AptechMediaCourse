using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    cubeAiSystemRed   RedCube;
    cubeAiSystemBlue  BlueCube;
    cubeAiSystemGreen GreenCube;
    public int giveDamage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red"))
        {
            RedCube = collision.gameObject.GetComponent<cubeAiSystemRed>();

            if (RedCube.health > 0)
            {
                RedCube.health -= giveDamage;
            }
            if (RedCube.health <= 0)
            {
               RedCube.health = 0;
              RedCube.winDecider.redCube--;
               Destroy(RedCube.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Blue"))
        {
            BlueCube = collision.gameObject.GetComponent<cubeAiSystemBlue>();

            if (BlueCube.health > 0)
            {
                BlueCube.health -= giveDamage;
            }
            if (BlueCube.health <= 0)
            {
                BlueCube.health = 0;
               BlueCube.winDecider.blueCube--;
                Destroy(BlueCube.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            GreenCube = collision.gameObject.GetComponent<cubeAiSystemGreen>();

            if (GreenCube.health > 0)
            {
                GreenCube.health -= giveDamage;
            }
            if (GreenCube.health <= 0)
            {
                GreenCube.health = 0;
                GreenCube.winDecider.greenCube--;
                Destroy(GreenCube.gameObject);
            }
        }
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

