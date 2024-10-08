using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") || Input.GetButton("Fire2"))
            animator.SetBool("Fire", true);
        else
        {
           animator.SetBool("Fire", false);
        }

    }
}
