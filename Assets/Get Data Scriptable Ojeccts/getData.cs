using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour
{
    [SerializeField]
    public filesAccessing data;


    private void Start()
    {
        Debug.Log(data.health);
    }




}
