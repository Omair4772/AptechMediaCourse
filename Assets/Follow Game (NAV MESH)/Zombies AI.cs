using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiesAI : MonoBehaviour
{
    
    public GameObject zombiesPrefab;
    public GameObject zombiesParent;
    public GameObject[] arrayLocation;
    private GameObject zombieCreated;

    public float zombiesSpwaningDelayTime;


    private void Start()
    {

        InvokeRepeating("SpwaningZombies", zombiesSpwaningDelayTime, zombiesSpwaningDelayTime);
    }

    private void SpwaningZombies()
    {
        int location = Random.Range(0,arrayLocation.Length);

         zombieCreated = Instantiate(zombiesPrefab, arrayLocation[location].transform.position, Quaternion.identity, zombiesParent.transform);
       
    }

}
