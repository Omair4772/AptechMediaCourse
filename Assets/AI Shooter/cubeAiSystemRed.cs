using System.Collections;
using UnityEngine;


public class cubeAiSystemRed : MonoBehaviour
{
    [Header("CUBE SECTION")]

    public float speed = 10f;
    public float range = 10f;

    RaycastHit hit;                           // SEARCH FOR WALL
    public LayerMask mask;                    // MOVING MASK
    public float watchShphereRadius = 1f;     // Radius for the SphereCast
    public float rotateSpeed = 40f;           // CUBE ROTATE SPEED FOR OTHER CUBE TO SHOOT IT

    public bool booliyan = true;              // FOR MOVING

    [Header("BULLET CREATION SECTION")]

    public GameObject bulletPrefab;
    private GameObject bulletParent;
    public float bulletSpeed = 60f;

    public float shootSpeed;
    private GameObject bullet;              // The temp Bullet Location
    public RaycastHit info;                 // IN SPHERE LOOK FOR OTHER CUBE
    public LayerMask hitLayers;
    public float bulletRange = 5f;          // Max distance the bullet can travel
    public bool activeShoot = false;

    private bool CubeHitted;


    [Header("Health SECTION")]
    public int health = 100;

    [Header("Win Decider")]
    public WinDecider winDecider;

    private void Start()
    {
        winDecider = FindAnyObjectByType<WinDecider>();
        winDecider.redCube++;
        bulletParent = GameObject.FindGameObjectWithTag("bulletParent");
        StartCoroutine(CubeMover());
    }

    private void Update()
    {
        if (info.collider != null)
        {
            CubeHitted = info.collider.gameObject.CompareTag("Blue") || info.collider.gameObject.CompareTag("Green");
        }
        else
        {
            return;
        }
    }
    IEnumerator CubeMover()
    {
        int moveDecider = Random.Range(0, 4);

        switch (moveDecider)
        {
            case 0:
                {
                    // MOVE FORWARD

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, transform.forward, out hit, range, mask))
                        {
                            booliyan = false;
                        }
                        else
                        {
                            transform.position += Vector3.forward * speed * Time.deltaTime;
                            yield return null;
                        }
                    }

                    yield return new WaitForSeconds(1f);
                    booliyan = true;
                    break;
                }

            case 1:
                {
                    //MOVE RIGHT 

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.right, out hit, range, mask))
                        {
                            booliyan = false;
                        }
                        else
                        {
                            transform.position += Vector3.right * speed * Time.deltaTime;
                            yield return null;
                        }
                    }
                    yield return new WaitForSeconds(1f);
                    booliyan = true;
                    break;
                }

            case 2:
                {
                    // MOVE LEFT

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.left, out hit, range, mask))
                        {
                            booliyan = false;
                        }
                        else
                        {
                            transform.position += Vector3.left * speed * Time.deltaTime;

                            yield return null;
                        }
                    }

                    yield return new WaitForSeconds(1f);
                    booliyan = true;
                    break;
                }

            case 3:
                {
                    // MOVE BACK

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.back, out hit, range, mask))
                        {
                            booliyan = false;
                        }
                        else
                        {
                            transform.position += Vector3.back * speed * Time.deltaTime;
                            yield return null;
                        }

                    }

                    yield return new WaitForSeconds(1f);
                    booliyan = true;
                    break;
                }
        }

        WatchOtherCubesInsideRadius();
        StartCoroutine(CubeMover());
    }

    public void WatchOtherCubesInsideRadius()
    {
        if (Physics.SphereCast(transform.position, watchShphereRadius, transform.position + transform.right * bulletRange, out info, hitLayers)) ;
        {
            ShootDecider();
        }
    }
    public void ShootDecider()
    {

        if (CubeHitted)
        {
            StartCoroutine(BulletsCreate());
        }
        else
        {
            activeShoot = false;
        }
    }
    IEnumerator BulletsCreate()
    {
        activeShoot = true;

        do
        {
            yield return new WaitForSeconds(shootSpeed);

            print("Bullet Created");

            // Create the bullet slightly in front of the shooter in the direction the shooter is facing
            Vector3 bulletSpawnPosition = transform.position + transform.right  * 1.5f;

            //create bullet
            GameObject tempBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity, bulletParent.transform);

            // Add force to the bullet to move it forward
            Rigidbody rb = tempBullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(transform.right * bulletSpeed);  // Adjust force as needed
            }
            Destroy(tempBullet, 1f);
        }
        while (!activeShoot);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.right * bulletRange, watchShphereRadius);

    }

}
