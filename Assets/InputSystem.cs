using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.0f;

    Vector3 obj1InitialPos;

    [SerializeField]
    GameObject practiceObj1;

    [SerializeField]
    GameObject practiceObj2;

    [SerializeField]
    GameObject practiceObj3;

    private void Start()
    {
        obj1InitialPos = practiceObj1.transform.position;
    }


    public void ResetPracticeObjects()
    {
        practiceObj1.transform.position = obj1InitialPos;
    }



    void Update()
    {
        //Keyboard
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("G");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Escape");
        }

        //Mouse
        // Vector3 mousePosition = Input.mousePosition;
        // Debug.Log("Mouse Position: " + mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked");
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Right mouse button held down");
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Debug.Log("Mouse Scroll: " + scroll);
        }
    }








    //////////////////Rotate Around////////////////////////

    public float speed1 = 10f; // Rotation speed

    public void StartRotatearound()
    {
        StartCoroutine(StartRotateAroundCoroutine());
    }

    IEnumerator StartRotateAroundCoroutine()
    {
        yield return null;
        practiceObj3.transform.RotateAround(transform.position, Vector3.up, speed1 * Time.deltaTime);
        StartCoroutine(StartRotateAroundCoroutine());
    }


    //////////////Rotate work////////////////////

    public float rotationSpeed = 45f; // Degrees per second
    //public Vector3 rotationSpeed1 = new Vector3(0, 245, 0);

    public void StartRotation()
    {
        StartCoroutine(RotattionCoroutine());
    }

    IEnumerator RotattionCoroutine()
    {
        yield return null;
        practiceObj3.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        // practiceObj3.transform.rotation *= Quaternion.Euler(rotationSpeed1 * Time.deltaTime);
        StartCoroutine(RotattionCoroutine());
    }


    //////////////////////////////////Lerp use///////////////////////////
    public float moveTime = 3f; // Duration of the move

    private float timer = 0f;

    public void MoveObjectUsingLerp()
    {
        timer = 0f;
        StartCoroutine(LerpMovingCoroutine());
    }

    IEnumerator LerpMovingCoroutine()
    {
        yield return null;
        // Update the timer based on time elapsed
        timer += Time.deltaTime / moveTime;
        // Ensure timer stays between 0 and 1
        timer = Mathf.Clamp01(timer);
        Debug.Log("Timer value" + timer);

        // Interpolate between startPosition and endPosition
        Vector3 currentPosition = Vector3.Lerp(practiceObj1.transform.position, practiceObj2.transform.position, timer);

        // Apply the position to the GameObject
        practiceObj1.transform.position = currentPosition;
        if (Vector3.Distance(practiceObj1.transform.position, practiceObj2.transform.position) > 0.001f)
        {
            StartCoroutine(LerpMovingCoroutine());
        }
    }


    ///////////////////////////////MOVE VIA MOVE TOWARDS///////////////////////////
    public void MoveObjectUsingMoveToward()
    {
        Debug.Log("MoveObject funtoin called");
        StartCoroutine(MoveTowardMovingCoroutine());
    }

    IEnumerator MoveTowardMovingCoroutine()
    {
        yield return null;
        var step = speed * Time.deltaTime;
        practiceObj1.transform.position = Vector3.MoveTowards(practiceObj1.transform.position,
        practiceObj2.transform.position, step);
        if (Vector3.Distance(practiceObj1.transform.position, practiceObj2.transform.position) > 0.001f)
        {
            StartCoroutine(MoveTowardMovingCoroutine());
        }
    }

}
