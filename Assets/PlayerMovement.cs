using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform  finishPoint;
    private Renderer colortochange;
    public GameObject[] blastEffects;


    public GameObject objectToInstantiate;
    public Transform objectParent;
    private Vector3 InstantiatePos = new Vector3(0, 0, 0);
    public int numberOfCubes = 5;
    int i = 1;


    private void Start()
    {
            InvokeRepeating(nameof(InstantiateCubes), 2f, 1f);
    }


    private void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;

        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;

        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;

        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;

        }
        if (movement.magnitude > 1) {
            movement.Normalize();            
        }

        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;
        transform.position = newPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            i++;
            StartCoroutine(CubeMover(other.gameObject));
        }
    }

    IEnumerator CubeMover(GameObject gameObject)
    {
        float startingPosition = 0f;
        float endPosition = 1f;

        while (startingPosition < endPosition)
        {
            startingPosition += Time.deltaTime;
            float t = startingPosition / endPosition;
            float c = t * endPosition;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, finishPoint.transform.position, t);
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, c);
            yield return null;
        }

        BlastEffect();
        Destroy(gameObject, 0f);
    }

    private void BlastEffect()
    {
        for(int i = 0; i < blastEffects.Length; i++)
        {
            blastEffects[i].SetActive(true);
            return;
        }
    }
    private void InstantiateCubes()
    {
        GameObject Cubes;

        if (i < numberOfCubes)
        {
            int x = Random.Range(0, 50);
            int z = Random.Range(0, 50);

            Vector3 position = InstantiatePos + objectParent.position + new Vector3(x, 0, z);
            Cubes = Instantiate(objectToInstantiate, position, Quaternion.identity);

            Cubes.GetComponent<Renderer>().material.color = Color.yellow;

            Cubes.transform.SetParent(objectParent);
        
        }
    }
}