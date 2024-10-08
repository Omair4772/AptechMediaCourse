using UnityEngine;

public class AiShooter : MonoBehaviour
{
    [Header("CUBE CREATION SECTION")]
    public GameObject[] cubeAIPrefab;
    public GameObject parentCube;
    public Transform[] positionToSpwan;
    public int spwaningSpeed = 10;

    private void Start()
    {
        InvokeRepeating("SpwaningCubes", 0, spwaningSpeed);
    }


    public void SpwaningCubes()
    {
        int positionDecider = Random.Range(0, positionToSpwan.Length);
        int cubeDecider = Random.Range(0, cubeAIPrefab.Length);

        GameObject shooter = Instantiate(cubeAIPrefab[cubeDecider], positionToSpwan[positionDecider].position, Quaternion.identity, parentCube.transform);
    }
}
