
using UnityEngine;

public class FindTagAndGiveMovement : MonoBehaviour
{
    public GameObject[] cubes; // Array of GameObjects
    public string[] tagToFind;         // Tag you want to find
    float acceleration = 500f;


    void Start()
    {
        for (int i = 0; i <= cubes.Length -1; i++)
        {
            if (cubes[i] != null)
            {
                if (FindObjectWithTag(cubes, tagToFind[i]))
                {
                    Rigidbody rigidbody = cubes[i].GetComponent<Rigidbody>();

                   //rigidbody.AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
                   // rigidbody.AddForce(new Vector3(0, 0, 10), ForceMode.VelocityChange);
                   rigidbody.AddForce(Vector3.forward * acceleration, ForceMode.Acceleration);
                }
                else { return; }
            }
        }

        
    }

        // Function to find a GameObject with a specific tag in an array
        GameObject FindObjectWithTag(GameObject[] objects, string tag)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null && obj.CompareTag(tag))
                {
                    return obj;
                }

            }
            return null; // Return null if no object is found with the tag
        }
}
