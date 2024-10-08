using UnityEngine;

public class CubeRunner : MonoBehaviour
{
   public int speed;
   

    private void Update()
    {
        #region Player Movement

        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;

        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;

        }
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

        #endregion


    }
}
