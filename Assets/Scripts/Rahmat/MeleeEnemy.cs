using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public float enemyRadius;
    public float attackRadius;
    public float enemySpeed;
    public float attackSpeed;
    public float health;
    public float damage;
    public float damagedDuration;
    public Transform attackOffset;
    public GameObject onHitDamagedPrefab;
    public GameObject meleeAttackPrefab;
    public Color damagedTintedColor;
    public LayerMask playerMask;
    private Transform player;
    private float nextAttack;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {

        Chasing();

    }
    private void Wandering()
    {

    }
    private void Chasing()
    {
        if (Physics.CheckSphere(transform.position, enemyRadius, playerMask))
        {
            agent.destination = player.transform.position;
            Attacking();

        }
        else
        {
            Wandering();
        }
    }
    private void Attacking()
    {
        if (Physics.CheckSphere(transform.position, attackRadius, playerMask))
        {
            agent.speed = 0f;
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                GameObject instantiatedGameObject = Instantiate(meleeAttackPrefab, attackOffset.position, Quaternion.identity);
                instantiatedGameObject.GetComponent<ProjectileController>().damage = damage;
                instantiatedGameObject.GetComponent<ProjectileController>().isMelee = true;

            }
        }
        else if (!Physics.CheckSphere(transform.position, attackRadius, playerMask))
        {
            agent.speed = enemySpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            GameObject damagedFX = Instantiate(onHitDamagedPrefab, transform.position, Quaternion.identity);
            Destroy(damagedFX, damagedDuration);
            Destroy(other);
        }
    }
}