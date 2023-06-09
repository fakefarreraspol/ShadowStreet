using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public ScoreScript scoreSC;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool room02;


    Animator animator;

    PlayerController controller;

    //audio
    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip stepClip;
    private void Awake()
    {
        player = GameObject.Find("XR Origin").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        attackRange = Random.Range(3, 10);
        health = Random.Range(20, 60);



        if (room02)
        {
            scoreSC = FindObjectOfType<ScoreScript>();
            
            audioSource.clip = stepClip;
            audioSource.volume = 1.0f;
            audioSource.Play();
            
        }


        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        controller.SetArsenal("One Pistol");

    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!room02)
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
        else
        {
            if (!playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();

        }

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        animator.SetFloat("Speed", 1);
        animator.SetBool("Aiming", false);
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        animator.SetFloat("Speed", 1);
        agent.SetDestination(player.position);
        animator.SetBool("Aiming", false);
    }

    private void AttackPlayer()
    {

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 targetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        transform.LookAt(targetPostition);
        //transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            audioSource.clip = shootClip;
            audioSource.volume = 0.4f;
            audioSource.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

        animator.SetFloat("Speed", 0.1f);
        animator.SetBool("Aiming", true);
        animator.SetBool("Squat", false);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        if (room02) scoreSC.AddPoints(100);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(30);
        }
        if (collision.gameObject.tag == "interactable")
        {
            TakeDamage(300);
        }
    }
}
