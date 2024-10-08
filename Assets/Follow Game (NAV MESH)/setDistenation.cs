using UnityEngine;
using UnityEngine.AI;

public class setDistenation : MonoBehaviour
{
    private NavMeshAgent agent;
    private CubeShooter player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CubeShooter>();
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
