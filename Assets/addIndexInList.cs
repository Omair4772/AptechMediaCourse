using System.Collections.Generic;
using UnityEngine;

public class addIndexInList : MonoBehaviour
{
     public List<string> list = new List<string>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           list.Add("GameObject");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           list.Remove("GameObject");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           list.Remove("Inserted");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            list.Insert(2, "Inserted");
        }
    }

}
