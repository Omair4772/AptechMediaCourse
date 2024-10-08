using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class ZombiesMove : MonoBehaviour
{

    [Header("zombies Health and Damage ")]

    public float ZombiesHealth;
    public float presentHealth;
    public float giveDamage = 5f;


    [Header("Zombies Thing")]
    public NavMeshAgent ZombieAgent;
    public Transform lookPoint;
    public Camera AttackingRaycastArea;
    public Transform PlayerBody;
    public LayerMask playerLayer;

    [Header("Zombies Guarding Var")]
    public GameObject[] Walkpoints;
    int currentZombiePosition = 0;
    public float ZombieSpeed;
    private float walkingPointRadius = 2;


    [Header("Zombies Attacking Var")]

    public float timeBtwAttack;
    bool previouslyAttack;

    [Header("Zombie Animation")]
    public Animator anim;


    [Header("Zombie Audio")]
    public AudioSource AttackingSound;

    [Header("Zombies MOOD")]
    public float visionRadius;
    public float AttackingRadius;
    public bool PlayerInvisionRadius;
    public bool PlayerInAttackingRadius;

    private bool NowPursuePlayer, AllowKill;


    private void Awake()
    {
        AllowKill = true;
        NowPursuePlayer = false;

        presentHealth = ZombiesHealth;
        ZombieAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {


        PlayerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        PlayerInAttackingRadius = Physics.CheckSphere(transform.position, AttackingRadius, playerLayer);

        if (!PlayerInvisionRadius && !PlayerInAttackingRadius && !NowPursuePlayer) { Guard(); }
        if (NowPursuePlayer || PlayerInvisionRadius && !PlayerInAttackingRadius) { Pursueplayer(); }
        if (PlayerInvisionRadius && PlayerInAttackingRadius) { Attackplayer(); }


    }

    private void Guard()
    {
        if (Vector3.Distance(Walkpoints[currentZombiePosition].transform.position, transform.position) < walkingPointRadius)
        {
            currentZombiePosition = Random.Range(0, Walkpoints.Length);
            if (currentZombiePosition >= Walkpoints.Length)
            {
                currentZombiePosition = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Walkpoints[currentZombiePosition].transform.position, Time.deltaTime * ZombieSpeed);
        //Zombies Facing
        transform.LookAt(Walkpoints[currentZombiePosition].transform.position);

    }
    private void Pursueplayer()
    {
        if (ZombieAgent.SetDestination(PlayerBody.position))
        {

            //animations
            anim.SetBool("Walking", false);
            anim.SetBool("Running", true);
            anim.SetBool("Attacking", false);
            anim.SetBool("Died", false);

        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Died", true);
        }
    }
    private void Attackplayer()
    {
        ZombieAgent.SetDestination(transform.position);
        transform.LookAt(lookPoint);

        //Animation
        anim.SetBool("Running", false);

        if (!previouslyAttack)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(AttackingRaycastArea.transform.position, AttackingRaycastArea.transform.forward, out hitInfo, AttackingRadius))
            {

                Debug.Log("Attacking : " + hitInfo.transform.name);

                PlayerMove playerBody = hitInfo.transform.GetComponent<PlayerMove>();

                if (playerBody != null)
                {

                    playerBody.PlayerHitDamage(giveDamage);
                }

                //Animation
                anim.SetBool("Walking", false);
                anim.SetBool("Running", false);
                anim.SetBool("Attacking", true);
                anim.SetBool("Died", false);

                //Sounds
                AttackingSound.Play();

            }
            previouslyAttack = true;
            Invoke(nameof(ActiveAttacking), timeBtwAttack);
        }
    }
    private void ActiveAttacking()
    {
        previouslyAttack = false;

    }

    
}