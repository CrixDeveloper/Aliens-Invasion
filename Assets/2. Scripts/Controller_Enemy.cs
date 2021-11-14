using UnityEngine;
using UnityEngine.AI;

public class Controller_Enemy : MonoBehaviour
{
    #region Variables to use: 

    private GameObject target;
    private NavMeshAgent agent;
    private Animator animator;
    public float enemyLife = 100;
    public float speed = 1.0f;
    public float damage = 5f;
    public bool attacking = false;
    public bool lookingAt = false;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckLife();
        FollowPlayer();
        //CheckAttack();
        //Attack();
        //FrontOfPlayer();
    }

    public void takeDamage(float damage)
    {
        enemyLife -= damage;

        if (enemyLife < 0)
        {
            enemyLife = 0;
        }
    }

    public void CheckLife()
    {
        if (target == null)
        {
            agent.isStopped = true;
            animator.CrossFadeInFixedTime("Vida0", 0.1f);
            Destroy(gameObject, 3f);
        }
    }

    public void FollowPlayer()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    public void CheckAttack()
    {
        if (target != null)
        {
            if (attacking) return;
            float distanceTarget = Vector3.Distance(target.transform.position, transform.position);

            if (distanceTarget <= 8.5f && lookingAt)
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        agent.speed = 0f;
        attacking = true;
        animator.SetTrigger("MustAttack");
        Invoke("RestartAtk", 1f);
    }

    public void FrontOfPlayer()
    {
        Vector3 forward = transform.forward;
        Vector3 targetPlayer = (GameObject.Find("Player").transform.position - transform.position).normalized;

        if (Vector3.Dot(forward, targetPlayer) < 0.6f)
        {
            lookingAt = false;
        }
        else
        {
            lookingAt = true;
        }
    }

    public void RestartAtk()
    {
        attacking = false;
        agent.speed = speed;
    }

    #endregion
}
