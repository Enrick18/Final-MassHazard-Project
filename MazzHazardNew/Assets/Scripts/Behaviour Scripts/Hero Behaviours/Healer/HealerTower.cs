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
    private IHealthSystem heroHealth;
    [SerializeField] private bool isAoe;

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


        if (!isAoe && sortedHealableAllies.Count > 0)
        {
            LookAtTarget();
            healRate -= Time.deltaTime;

            foreach (KeyValuePair<GameObject, IHealthSystem> kvp in sortedHealableAllies)
            {
                heroHealth = kvp.Value;

                if (healRate <= 0 && kvp.Value.GetCurrentHealth() > 0)
                {
                    healRate = timeBetweenHeals;
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isHealing", true);
                    break;
                }
            }
        }
        else if (isAoe && sortedHealableAllies.Count > 0) 
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isHealing", true);
        }
        

        if (sortedHealableAllies.Count <= 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isHealing", false);
        }

    }

    void LookAtTarget()
    {
        if (heroHealth != null)
        {
            //transform.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(heroHealth.GetGameObject().transform.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }
    }

    public void HealTower() 
    {
        if (!isAoe)
        {
            heroHealth.HealDamage(healAmount, heroHealth.GetMaxHealth());
            if (heroHealth.GetCurrentHealth() >= heroHealth.GetMaxHealth())
            {
                _healableAllies.Remove(heroHealth.GetGameObject());
                Debug.Log("Fully Healed");
            }
        }
        else 
        {
            Debug.Log("Aoe");
            foreach (KeyValuePair<GameObject, IHealthSystem> hero in _healableAllies.ToList()) 
            {
                heroHealth = hero.Value;
                heroHealth.HealDamage(healAmount, heroHealth.GetMaxHealth());
                if (heroHealth.GetCurrentHealth() >= heroHealth.GetMaxHealth())
                {
                    if (_healableAllies.ContainsKey(heroHealth.GetGameObject()))
                        _healableAllies.Remove(heroHealth.GetGameObject());
                }
            }
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

