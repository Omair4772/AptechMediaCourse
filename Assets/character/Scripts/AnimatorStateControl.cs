using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateControl : MonoBehaviour
{
    private Animator animator;

    float velocity = 0.0f,
        accelaration = 0.1f,
        deaccelaration = 0.5f;

    int velocityHash = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool rightPressed = Input.GetKey(KeyCode.LeftShift);

        if(forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * accelaration;
        }

        if(!forwardPressed && velocity > 0.1f)
        {
            velocity -= Time.deltaTime * deaccelaration;
        }

        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(velocityHash, velocity);
    }
}
