using System.Collections;
using System.Collections.Generic;
using System.Linq; // Added to use LINQ queries
using UnityEngine;

public class HealerTower : MonoBehaviour, IKillable
{
    public float range = 5f;
    public float healAmount = 3f;
    public float timeBetweenHeals = 1f;
    public float healRate;
    public LayerMask allyLayer;
    public GameObject healingEffectPrefab;
    public Transform launcherModel;
    private Coroutine healCoroutine;
    private Dictionary<GameObject, IHealthSystem> _healableAllies = new Dictionary<GameObject, IHealthSystem>();
    public Dictionary<GameObject, IHealthSystem> healableAllies => _healableAllies;

    private Dictionary<GameObject, IHealthSystem> sortedHealableAllies = new Dictionary<GameObject, IHealthSystem>();

    private Collider[] allies;

    private bool isHealing;
    public Animator anim;

    private bool needsHealing = false;


    private void Start()
    {
        anim.SetBool("isIdle", true);
    }
    private void Update()
    {

        // Find all nearby allies
        allies = Physics.OverlapSphere(transform.position, range, allyLayer);

        foreach (var ally in allies)
        {
            var allyHealthController = ally.GetComponent<IHealthSystem>();

            if (allyHealthController.GetCurrentHealth() < allyHealthController.GetMaxHealth())
            {
                if (!_healableAllies.ContainsKey(ally.gameObject))
                {
                    _healableAllies.Add(ally.gameObject, allyHealthController);
                }

            }

        }
        sortedHealableAllies = _healableAllies.OrderBy(x => x.Value.GetCurrentHealth()).ToDictionary(x => x.Key, x => x.Value);

        if (sortedHealableAllies.Count > 1)
            if (sortedHealableAllies.ContainsKey(transform.gameObject))
            {
                sortedHealableAllies.Remove(transform.gameObject);
                needsHealing = true;
            }

        if (sortedHealableAllies.Count <= 0 && needsHealing)
        {
            sortedHealableAllies.Add(transform.gameObject, transform.GetComponent<IHealthSystem>());
            needsHealing = false;
        }

        healRate -= Time.deltaTime;

        foreach (KeyValuePair<GameObject, IHealthSystem> kvp in sortedHealableAllies)
        {


            if (healRate <= 0 && kvp.Value.GetCurrentHealth() > 0)
            {
                healRate = timeBetweenHeals;
                anim.SetBool("isIdle", false);
                anim.SetBool("isHealing", true);

                kvp.Value.HealDamage(healAmount);
                if (kvp.Value.GetCurrentHealth() >= kvp.Value.GetMaxHealth())
                {
                    _healableAllies.Remove(kvp.Key);
                    Debug.Log("Fully Healed");
                }
                break;


            }
        }

        if (sortedHealableAllies.Count <= 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isHealing", false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        // Draw a wire sphere around the tower to visualize its range in the Unity editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void IsDead()
    {
        this.enabled = false;
    }
}

