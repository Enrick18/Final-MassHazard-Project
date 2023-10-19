using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour, IKillable
{
    public float range = 5f; // The range of the tower
    public Transform target; // The transform of the enemy the tower is currently blocking
    public LayerMask whatIsEnemy;
    private Collider[] colliders; // An array to store all the colliders within the tower's range

    public Animator model;

    private void Awake()
    {
        colliders = new Collider[10]; // Create an array to store up to 10 colliders
    }

    private void FixedUpdate()
    {
        // Get all the colliders within the range of the tower
        colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        // Loop through all the colliders and find the closest enemy
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach(Collider col in colliders)
        {
            if (col.CompareTag("Enemy"))
            {
                Transform enemyTransform = col.transform;
                float distance = Vector3.Distance(transform.position, enemyTransform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemyTransform;
                }
            }
        }

        // If the closest enemy has changed, rotate the tower towards it
        if (closestEnemy != target)
        {
            target = closestEnemy;
        }

        if (target != null)
        {
            model.transform.rotation = Quaternion.Slerp (model.transform.rotation, Quaternion.LookRotation(target.position - model.transform.position), 5f * Time.deltaTime);
            model.transform.rotation = Quaternion.Euler(0f, model.transform.rotation.eulerAngles.y, 0f);
            // Vector3 targetDirection = target.position - transform.position;
            // Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void IsDead()
    {
        this.enabled = false;
    }
}

