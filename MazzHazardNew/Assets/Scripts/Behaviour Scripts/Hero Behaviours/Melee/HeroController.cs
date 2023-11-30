using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroController : MonoBehaviour, IKillable, IHeroStats
{
    AudioManager audioManager;

    private int _enemiesBlocked = 0;
    public int enemiesBlocked => _enemiesBlocked;
    [SerializeField] private int _blockCount = 1;
    public int blockCount => _blockCount;
    public float damageAmount;
    public float timeBetweenAttacks = 1f;
    private float attackCounter;
    private Dictionary<GameObject, EnemyMove> _enemyBlockList = new Dictionary<GameObject, EnemyMove>();
    public Dictionary<GameObject, EnemyMove> enemyBlockList => _enemyBlockList;
    private List<GameObject> keysToRemove = new List<GameObject>();
    public string blockTarget = "Enemy";
    public Transform launcherModel;
    public Animator anim;
    private IHealthSystem heroHealth;
    private bool isAttacking;
    private IHealthSystem enemyHealth;

    public bool isAoeAttack = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        heroHealth = GetComponent<IHealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_enemyBlockList.Count);
        int currentBlockCount = 0;

        foreach (KeyValuePair<GameObject, EnemyMove> kvp in _enemyBlockList)
        {

            if (kvp.Key != null)
            {
                currentBlockCount += kvp.Value.blockRequirement;
            }
        }

        _enemiesBlocked = currentBlockCount;

        if (!isAoeAttack && _enemyBlockList.Count > 0)
        {
            attackCounter -= Time.deltaTime;

            foreach (KeyValuePair<GameObject, EnemyMove> kvp in _enemyBlockList)
            {

                if (kvp.Value != null)
                {
                    enemyHealth = kvp.Value.GetComponent<IHealthSystem>();
                    if (attackCounter <= 0)
                    {
                        audioManager.PlaySFX(audioManager.attacking);
                        attackCounter = timeBetweenAttacks;
                        Debug.Log(_enemyBlockList.Count);
                        anim.SetBool("isIdle", false);
                        anim.SetBool("isAttacking", true);
                        break;
                    }
                }
                else
                {
                    keysToRemove.Add(kvp.Key);
                }

            }

            foreach (GameObject key in keysToRemove)
            {
                _enemyBlockList.Remove(key);
            }

        }
        else if (isAoeAttack && _enemyBlockList.Count > 0) 
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
        }


        if (_enemyBlockList.Count <= 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            if (!other.GetComponent<BombController>()) 
            {
                var enemy = other.GetComponent<EnemyMove>();
                int blockRequirement = enemy.blockRequirement;

                if (other.gameObject.tag == blockTarget)
                {
                    if ((_enemiesBlocked + blockRequirement) <= blockCount) // check if enemies doesnt exceed block count
                    {
                        _enemiesBlocked += blockRequirement;
                        enemy.StopEnemy(gameObject);
                        enemy.isBlocked = true;
                        _enemyBlockList.Add(enemy.gameObject, enemy);
                    }
                }
            }
            
        }
    }
    public void DealDamage()
    {
        
        if (!isAoeAttack && _enemyBlockList.Count > 0) 
        {
            enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(heroHealth.GetElementType(), enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
            if (enemyHealth.GetCurrentHealth() <= 0)
            {
                _enemyBlockList.Remove(enemyHealth.GetGameObject());
                Debug.Log("Dead: " + _enemyBlockList.Count);
            }

        }
        else
        {
            if (isAoeAttack) 
            {
                foreach (KeyValuePair<GameObject, EnemyMove> enemy in _enemyBlockList.ToList())
                {
                    if (enemy.Value != null)
                    {
                        enemyHealth = enemy.Value.GetComponent<IHealthSystem>();
                        enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(heroHealth.GetElementType(), enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());

                        if (enemyHealth.GetCurrentHealth() <= 0)
                        {
                            if (_enemyBlockList.ContainsKey(enemy.Key))
                                _enemyBlockList.Remove(enemy.Key);
                        }
                    }
                    else
                    {
                        _enemyBlockList.Remove(enemy.Key);
                    }
                }
            }
            
        }

    }


    public void IsDead()
    {
        this.enabled = false;
    }

    public void ModifyHeroDamage(float multiplier)
    {
        damageAmount *= multiplier;
    }

}
