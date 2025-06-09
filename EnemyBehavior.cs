using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target; // Reference to the player or target transform
    public float speed = 2f; // Enemy's movement speed
    public float attackRange = 2f; // Range at which the enemy can attack
    public float attackDamage = 10f; // Amount of damage the enemy deals
    public float health = 100f; // Enemy's health

    private NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
    }

    void Update()
    {
        // Check if the target is within attack range
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            // Attack the target
            AttackTarget();
        }
        else
        {
            // Move towards the target
            MoveToTarget();
        }

        // Reduce the enemy's health if it's below 0
        if (health <= 0)
        {
            Die();
        }
    }

    private void MoveToTarget()
    {
        // Set the destination for the NavMeshAgent
        navAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        // Implement the attack logic here
        // For example, you can deal damage to the target
        
        //target.GetComponent<Health>().TakeDamage(attackDamage);
    }

    private void Die()
    {
        // Implement the death logic here
        // For example, you can destroy the enemy GameObject
        Destroy(gameObject);
    }
}
