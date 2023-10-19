using UnityEngine;

public class TreantSpikes : MonoBehaviour
{
    public GameObject spikesPrefab;
    public LayerMask whatIsEnemy;
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public float damage;

    private float attackTimer = 0f;
    [SerializeField] public ElementType element;
    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    private void Attack()
    {
        // Detect enemies within the attack range.
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);

        foreach (Collider enemyCollider in enemies)
        {
            // Check if the detected object is an enemy.
            var enemy = enemyCollider.GetComponent<HeroDetect>();
            if (enemy != null)
            {
                // Create a rotation that rotates -90 degrees around the X-axis.
                Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
                // Spawn spikes at the enemy's position.
                var spikes = Instantiate(spikesPrefab, enemy.transform.position, rotation);
                spikes.GetComponent<SpikeBehaviour>().element = element;
                spikes.GetComponent<SpikeBehaviour>().damageAmount = damage;
                //Debug.Log(enemy.transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
