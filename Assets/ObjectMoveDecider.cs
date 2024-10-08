using System.Collections;
using UnityEngine;

public class ObjectMoveDecider : MonoBehaviour
{
    public int objectSpeed, specialMove;
    public float range;
    public float wallrange;
    bool move = true;

    public LayerMask layerMask, wall;
    RaycastHit hit;

    void Update()
    {

        ObjectToMove();
        
    }

    private void ObjectToMove()
     {   
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, range, layerMask) && move)
        {
            transform.position += Vector3.back;
            Vector3 objectPosition = transform.position + Vector3.back * objectSpeed * Time.deltaTime;
            transform.position = objectPosition;
        }

        if (Physics.Raycast(transform.position, Vector3.back, out hit, range, layerMask) && move)
        {

            transform.position += Vector3.forward;
            Vector3 objectPosition = transform.position + Vector3.forward * objectSpeed * Time.deltaTime;
            transform.position = objectPosition;
        }

        if (Physics.Raycast(transform.position, Vector3.right, out hit, range, layerMask) && move)
        {

            transform.position += Vector3.left;
            Vector3 objectPosition =   transform.position + Vector3.left * objectSpeed * Time.deltaTime;
            transform.position = objectPosition;
        }

        if (Physics.Raycast(transform.position, Vector3.right, out hit, range, layerMask) && move)
        {

            transform.position += Vector3.left;
            Vector3 objectPosition = transform.position + Vector3.left * objectSpeed * Time.deltaTime;
            transform.position = objectPosition;
        }

        StartCoroutine(mover());
    }

    IEnumerator mover()
    {
        int i = Random.Range(0, 2);

        switch (i)
        {
            case 0:
                {
                    move = false;
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit, wallrange, wall))
                    {
                        transform.position += Vector3.left;
                        Vector3 objectPosition = transform.position + Vector3.left * specialMove * Time.deltaTime;
                    }

                    break;
                }
            case 1:
                {
                    move = false;
                    transform.position += Vector3.right;
                    Vector3 objectPosition = transform.position + Vector3.right * specialMove * Time.deltaTime;
                    transform.position += objectPosition;

                    break;
                }

        }
        yield return null;

        move = true;
    }
}
