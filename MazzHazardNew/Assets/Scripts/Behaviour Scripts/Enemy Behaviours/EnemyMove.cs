using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour, IKillable
{
    NavMeshAgent agent;
    private UnitPathing thePath;
    int wayPointIndex;
    [SerializeField]
    private Vector3 target;
    public float distance = 2.7f;
    public int blockRequirement = 1;
    private float movementSpeed;
    private bool _isStopped = false;
    public bool isStopped => _isStopped;
    private Vector3 saveTransform;
    [SerializeField]private GameObject hero = null;
    public Animator anim;
    public EnemyEventRaiser counter;
    public bool isBlocked;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        movementSpeed = agent.speed;
        thePath = FindObjectOfType<UnitPathing>();
        if(thePath ==  null)
        {
            var findGameManager = GameObject.Find("GameManager");
            thePath = findGameManager.GetComponent<UnitPathing>();
        }
        UpdateDestination();

    }
    void Update()
    {

        if (Vector3.Distance(transform.position, target) < distance)
        {
            IterateWayPointIndex();
        }


        if (hero == null )// to resume movement when no hero blocking
        {
                agent.enabled = true;
                isBlocked = false;
                anim.SetBool("isWalking", true);
                agent.isStopped = false;
                agent.speed = movementSpeed;
                _isStopped = false;
                UpdateDestination();
        }
        else
        {
            transform.position = saveTransform;
        }
    }


    void UpdateDestination()
    {
        target = thePath.points[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        wayPointIndex++;
    }

    public void StopEnemy(GameObject GO)
    {
        if (!_isStopped) 
        {
            saveTransform = transform.position;
            hero = GO;
            agent.speed = 0;
            _isStopped = true;
            agent.isStopped = true;
            agent.enabled = false;
        }
        
    }

    public void IsDead()
    {
        if (agent.enabled == true) 
        {
            agent.isStopped = true;
        }
        counter.SendDeathEvent();
        this.enabled = false;
    }
}
