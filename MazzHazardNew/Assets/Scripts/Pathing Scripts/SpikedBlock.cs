using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBlock : MonoBehaviour
{
    private string target = "Hero";
    [SerializeField]private float damageAmount;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            var hero = other.GetComponent<HealthController>();

            hero.TakePureDamage(damageAmount);
        }
        else if (other.tag == "Enemy") 
        {
            Debug.Log("Damage");

            var enemy = other.GetComponent<HealthController>();

            enemy.TakePureDamage(damageAmount*0.3f);
        }
    }

}
