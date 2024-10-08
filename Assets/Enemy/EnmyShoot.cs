using System.Collections;
using UnityEngine;

public class EnmyShoot : MonoBehaviour
{
    public bool playerInRange = false;

    public int enemyHealth = 60;
    public int waitAfterOneShot = 10;
    public playerHealth playerHealth;

    RaycastHit hit;

    public GameObject bullet;
    public Camera FpsCam;
    public Transform attackPoint;
    public float shootForce, upWardForce;

    public LayerMask layerMask;
    public float searchRadius = 2.5f;
    public float maxDistance = 10.0f;
    public float rotationSpeed = 50.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, searchRadius, transform.forward, out hit, maxDistance, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                animator.SetBool("Shooting", true);
                LookTowordsPlayer(hit);
                if (!playerInRange)
                {
                    playerInRange = true;
                    StartCoroutine(ShootPlayer());
                }
            }
        }
        else
        {
            animator.SetBool("Shooting", false);
            if (playerInRange)
            {
                StopAllCoroutines();
                playerInRange = false;
            }
        }
    }

    IEnumerator ShootPlayer()
    {
        //Find The Exect Hit Point using Raycast        Vector3(0.5,0.5,0) = middle of screen
        Ray ray = FpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //ray to middle of screen
        RaycastHit Hit;

        //check if ray Hit Something
        Vector3 targetHitted;
        if (Physics.Raycast(ray, out Hit))
        {
            targetHitted = Hit.point;
        }
        else
        {
            targetHitted = ray.GetPoint(75); //Making Point far from player
        }

        //calculate distance from player to hitted point
        Vector3 directionwithoutspread = targetHitted - attackPoint.position;
        //Instantiate Bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        Destroy(currentBullet, 1f);
        //Rotate Bullet to shoot Direction
        currentBullet.transform.forward = directionwithoutspread.normalized;
        //Add force to Bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionwithoutspread.normalized * shootForce, ForceMode.Impulse);
        //Bouncing Bullets
        currentBullet.GetComponent<Rigidbody>().AddForce(FpsCam.transform.up * upWardForce, ForceMode.Impulse);
        print("Hitted");

        yield return new WaitForSeconds(waitAfterOneShot);
        
        StartCoroutine(ShootPlayer());
    }
    private void LookTowordsPlayer(RaycastHit hit)
    {
        //LOOk Toward The player
        Vector3 directionToPlayer = hit.collider.transform.position - transform.position;
        directionToPlayer.y = 0; // Keep the enemy looking horizontally
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    public void takeDamage(int damage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damage;
        }

        if (enemyHealth <= 0)
        {
            animator.SetBool("Die", true);

            Destroy(gameObject, 3);
        }
    }
    // Draw the Gizmos to visualize the SphereCast
    void OnDrawGizmos()
    {
        // Start position of the sphere
        Vector3 origin = transform.position;

        // If there was a hit, draw a sphere at the hit point
        if (hit.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hit.point, searchRadius);
        }

        // Draw the sphere cast path
        Gizmos.color = Color.green;
        Vector3 directionWorld = transform.forward;
        Gizmos.DrawRay(origin, directionWorld * maxDistance);

        // Visualize the start and end points of the SphereCast
        Gizmos.DrawWireSphere(origin, searchRadius);
        Gizmos.DrawWireSphere(origin + directionWorld * maxDistance, searchRadius);
    }
}
