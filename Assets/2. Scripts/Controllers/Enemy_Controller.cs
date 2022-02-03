using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_Controller : MonoBehaviour
{
    #region Variables to use: 

    // Private Variables: 
    private GameObject player;
    private NavMeshAgent agent;
    private Health enemyHealth;
    private Health playerLife;
    private Animator animator;
    protected AudioSource audioSource;
    protected AudioSource audioSource2;

    [Header("References:")]
    public GameObject fuelPrefab;
    public AudioClip alienHurtSound;
    public AudioClip playerHurtSound;

    [Header("Boolean Values:")]
    public bool dead = false;
    public bool attacking = false;

    [Header("Attributes:")]
    public float damage = 25f;
    public float agentSpeed = 8f;
    public float agentAngularSpeed = 120f;
    public float timeLastAttack;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPlayer();
        CheckLife();
        CheckAttack();
    }

    private void FollowPlayer()
    {
        if (dead) return;

        agent.destination = player.transform.position;
    }

    public void CheckLife()
    {
        if (dead) return;

        if (enemyHealth.value <= 0)
        {
            audioSource.PlayOneShot(alienHurtSound);
            dead = true;
            agent.isStopped = true;
            animator.CrossFadeInFixedTime("Dead", 0.1f);
            Destroy(gameObject, 3f);

            Instantiate(fuelPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void CheckAttack()
    {
        if (Time.time < timeLastAttack + 1) return;

        if (dead) return;
        if (attacking) return;
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= 4.0)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        timeLastAttack = Time.time;
        Manager_Energy.energyCount -= 1;
        FindObjectOfType<Manager_Energy>().GetComponent<Text>().text = " " + Manager_Energy.energyCount.ToString();

        audioSource2.PlayOneShot(playerHurtSound);
        playerLife.TakeDamage(damage);
        agent.speed = 0;
        agent.angularSpeed = 0;
        attacking = true;
        animator.SetTrigger("MustAttack");
        Invoke("RestartAttack", 2f);
    }

    private void RestartAttack()
    {
        attacking = false;
        agent.speed = agentSpeed;
        agent.angularSpeed = agentAngularSpeed;
    }

    #endregion
}
