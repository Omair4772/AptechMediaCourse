using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistroyOBJ : MonoBehaviour
{
    public GameObject[] box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            print("Tag Compared");
            for(int i = 0; i <= box.Length -1; i++)
            {
                print("IN the For Loop");
                Destroy(box[i]);
            }
        }
    }
}
