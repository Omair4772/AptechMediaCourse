using UnityEngine;

public class BulletForTPP : MonoBehaviour
{
    public int giveDamage = 20;
    private EnmyShoot enmyShoot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enmyShoot = collision.gameObject.GetComponent<EnmyShoot>();
            enmyShoot.takeDamage(giveDamage);
        }  
        else
        {
            return;
        }
    }
}

