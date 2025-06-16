using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Transform target; // Reference to the target transform
    public float damage = 20f; // Amount of damage the projectile deals
    public float speed = 10f; // Speed of the projectile
    public float lifeTime = 5f; // Time before the projectile is destroyed

    private float elapsedTime = 0f;

    void Update()
    {
        // Move the projectile towards the target
        MoveTowardsTarget();

        // Destroy the projectile after its lifetime expires
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void MoveTowardsTarget()
    {
        if (target == null) return;

        // Calculate the direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Make the projectile look at the target
        transform.LookAt(target);

        // Move the projectile in the calculated direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
        if (enemy != null && target != null && other.transform == target)
        {
            // Deal damage to the target
            enemy.TakeDamage(damage);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
