using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    bool A;

    private void Update()
    {


       float distance = Vector3.Distance(transform.position, target.position);


        if(distance > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

       // this.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
