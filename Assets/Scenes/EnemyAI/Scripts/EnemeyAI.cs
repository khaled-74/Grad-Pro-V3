using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemeyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    Animator animator;
    //Patroling 
    public Vector3 walkPoint;
    bool walkPointSet; 
    public float walkPointRange;
  //  public GameObject projectile;
    //Attacking
    public float timeBetweenAttacks=0.01f;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Player Health (Hero)
    public Health playerHealth;

 
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        animator.SetBool("isAttacking", false);

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        //agent.speed = 3.5f;
        //animator.SetBool("isRunning", false);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //agent.speed = 6f;
        //animator.SetBool("isRunning",true);
        animator.SetBool("isAttacking", false);
        
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        //transform.LookAt(player);

        if (!alreadyAttacked)
        {
            playerHealth.Damage(10f);
            animator.SetBool("isAttacking", true);

            ///Attack code here
            ///
         
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //         if ) { TakeDamage(10); }
            //void OnCollisionEnter(Collision collision)
            //{
            //    foreach (ContactPoint contact in collision.contacts)
            //    {
            //        Debug.DrawRay(contact.point, contact.normal, Color.white);
            //    }
            //    if (collision.relativeVelocity.magnitude > 2) ;
            //    audioSource.Play();
            //}
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("isAttacking", false);

    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            Invoke(nameof(DestroyEnemy), 0.5f);    
            
        }

    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //enemy taking damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            TakeDamage(100);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
 
}

