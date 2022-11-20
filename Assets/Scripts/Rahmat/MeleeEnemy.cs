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
    public float health;
    public float damage;
    public float fireRate;
    public float damagedDuration;
    public GameObject onHitDamagedPrefab;
    public Color damagedTintedColor;
    public LayerMask playerMask;
    private Transform player;
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