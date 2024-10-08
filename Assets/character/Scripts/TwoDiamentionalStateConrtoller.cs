using UnityEngine;

public class TwoDiamentionalStateConrtoller : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float accelaration = 2.0f;
    public float deccelaration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    //Increase Performance
    int velocityZHash, velocityXHash;

    // Start is called before the first frame update
    void Start()
    {
        //This will search an Animator Component on the GameObject
        animator = GetComponent<Animator>();

        //Increase Performance
        velocityZHash = Animator.StringToHash("Velocity Z");
        velocityXHash = Animator.StringToHash("Velocity X");
    }

    //Handles accelaration and decelaration
    void changeVelocity(bool forwardPressed, bool backPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {

        // if player press forward velocity of Z position will increase
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * accelaration;
        }

        // increase velocity in left diarection
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * accelaration;
        }

        // increase velocity in right diarection
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * accelaration;
        }

        //Decrease VelocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deccelaration;
        }

        // increase velocityX if left is not pressed and value X < 0
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deccelaration;
        }

        //decrease velocityX if right is not pressed and velocityX > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deccelaration;
        }


    }

    // Handles Reset and Locking of velocity 
    void  lockDrResetVelocity(bool forwardPressed  , bool backPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {


        // Reset velocityZ
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        // reset VelocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX -= 0.0f;
        }

        //look forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        // Decrease To the minimum Walk Velocity
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {

            velocityZ -= Time.deltaTime * deccelaration;

            // Round To the currentmaxVelocity if within offset
            if (velocityZ > currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        //Round to the currentMax Velocity if within offset
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        // set Current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        // Handle Change Velocity
        changeVelocity(forwardPressed,backPressed,leftPressed,rightPressed,runPressed,currentMaxVelocity);
        lockDrResetVelocity(forwardPressed,backPressed,leftPressed,rightPressed, runPressed,currentMaxVelocity);
       
        // set the parameters to our local variables values
        animator.SetFloat(velocityZHash, velocityZ);
        animator.SetFloat(velocityXHash, velocityX);
    }
}
