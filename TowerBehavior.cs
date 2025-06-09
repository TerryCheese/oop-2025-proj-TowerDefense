using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be fired
    public float attackRange = 10f; // Range at which the tower can attack
    public float attackDamage = 20f; // Amount of damage the tower deals
    public float attackRate = 1f; // Rate at which the tower attacks (in attacks per second)
    public float rotationSpeed = 5f; // Speed at which the tower rotates to face the target

    private float nextAttackTime = 0f; // Time when the tower can attack next
    private GameObject currentTarget = null; // The current target the tower is aiming at

    void Update()
    {
        // Find the closest enemy within the attack range
        GameObject closestEnemy = FindClosestEnemy();

        // If there's an enemy within range, attack it
        if (closestEnemy != null)
        {
            // If the target has changed, update the currentTarget reference
            if (currentTarget != closestEnemy)
            {
                currentTarget = closestEnemy;
            }

            // Rotate the tower to face the target
            RotateTowardsTarget();

            // Attack the target
            AttackEnemy(closestEnemy);
        }
        else
        {
            // No target, reset the currentTarget reference
            currentTarget = null;
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = attackRange;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void RotateTowardsTarget()
    {
        if (currentTarget == null) return;

        // Calculate the direction towards the target
        Vector3 targetDirection = (currentTarget.transform.position - transform.position).normalized;

        // Rotate the tower towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void AttackEnemy(GameObject enemy)
    {
        // Check if it's time to attack
        if (Time.time >= nextAttackTime)
        {
            // Instantiate the projectile and fire it at the enemy
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<ProjectileBehavior>().target = enemy.transform;
            projectile.GetComponent<ProjectileBehavior>().damage = attackDamage;

            // Update the next attack time
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
