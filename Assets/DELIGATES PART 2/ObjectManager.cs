using System;
using System.Collections;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static event Action<GameObject, string> OnObjectCreated;

    public GameObject objectPrefab; // Prefab to instantiate
    private float spawnInterval = 0.5f;
    private string[] colorGroup = { "Red", "Blue", "Green" }; // Group names

    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            string group = colorGroup[UnityEngine.Random.Range(0, colorGroup.Length)];

            GameObject newObj = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);

            // Ensure ObjectBehaviour is attached and initialize
            ObjectBehaviour behaviour = newObj.GetComponent<ObjectBehaviour>();
            if (behaviour != null)
            {
                behaviour.Initialize(group);
                OnObjectCreated?.Invoke(newObj, group);
            }
            else
            {
                Debug.LogError("ObjectBehaviour script is missing on the instantiated object!");
            }
        }
    }
}
