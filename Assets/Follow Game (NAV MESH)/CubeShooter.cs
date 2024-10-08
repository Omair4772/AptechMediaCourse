using UnityEngine;

public class CubeShooter : MonoBehaviour
{
    public int speed;
    public int Bulletspeed;
    public float bulletRange = 50f; // Max distance the bullet can travel
    
    public LayerMask hitLayers;
    public Transform bulletOrigin; // Position where the bullet is fired from
    private float bulletRadius = 0.5f;     // Radius of the bullet for the SphereCast
    public float upWardForce;
    public GameObject bulletprefab;

    public GameObject particalSystem;



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;

        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;

        }
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;
        transform.position = newPosition;

        ShootingWithRaycast();
    }

    public void ShootingWithRaycast()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (Physics.SphereCast(bulletOrigin.position, bulletRadius, bulletOrigin.forward, out hit, bulletRange, hitLayers))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                
                //create bullet
                GameObject bullet = Instantiate(bulletprefab, bulletOrigin.transform.position, Quaternion.identity);
                Destroy(bullet, 2f);

                // Calculate direction towards the hit point
                Vector3 targetDirection = hit.point - bulletOrigin.position;

                //Rotate Bullet to shoot Direction
                bullet.transform.forward = targetDirection.normalized;

                //Add force to Bullet
                bullet.GetComponent<Rigidbody>().AddForce(targetDirection.normalized * Bulletspeed, ForceMode.Impulse);

                particalSystem.transform.position = hit.collider.gameObject.transform.position;
                particalSystem.SetActive(true);
                Destroy(hit.collider.gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {

        if (bulletOrigin != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(bulletOrigin.position + bulletOrigin.forward * bulletRange, bulletRadius);
        }

    }
}
