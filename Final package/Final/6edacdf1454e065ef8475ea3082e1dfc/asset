using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public string targetName = "PlayerBase"; // Name of the target GameObject in the scene
    public float speed = 2f; // Enemy's movement speed
    public float attackRange = 2f; // Range at which the enemy can attack
    public float attackDamage = 10f; // Amount of damage the enemy deals
    public float maxHealth = 100f; // Enemy's maximum health
    public GameObject healthBarPrefab; // Prefab for the health bar UI element
    private Slider healthBar; // Reference to the enemy's health bar UI element

    private NavMeshAgent navAgent;
    private float currentHealth;
    private Transform target;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
        currentHealth = maxHealth;

        // Find the target by name
        GameObject targetObj = GameObject.Find(targetName);
        if (targetObj != null)
        {
            target = targetObj.transform;
        }
        else
        {
            Debug.LogError("EnemyBehavior: Target GameObject with name '" + targetName + "' not found!");
        }

        healthBar = healthBarPrefab.GetComponent<Slider>();
        UpdateHealthBar();
    }

    void Update()
    {
        if (target == null) return;

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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void MoveToTarget()
    {
        if (target != null)
            navAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        // Implement the attack logic here
        // For example, you can deal damage to the target
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0f);
        UpdateHealthBar();
    }

    private void Die()
    {
        // Implement the death logic here
        // For example, you can destroy the enemy GameObject
        Destroy(gameObject);

        // Notify the CoinSystem that an enemy has been defeated
        FindFirstObjectByType<CoinSystem>().AddCoins(10); // Adjust the number of coins as needed
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
