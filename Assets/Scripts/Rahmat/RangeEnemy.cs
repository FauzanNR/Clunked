using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RangeEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Transform player;
    public Transform projectileSpawn;
    public float health;
    public float damage;
    public float fireRate;
    public float attackRange;
    public float projectileSpeed;
    public float maxProjectileDistance;
    public float damagedDuration;
    public bool isCanPassThru = false;
    public GameObject onHitDamagedPrefab;
    public Color damagedTintedColor;
    public GameObject vfx;
    public LayerMask playerMask;
    private NavMeshAgent agent;
    private float nextFire;
    private bool inRange = false;
    private Animator animator;
    private int isShotHash;
    private void Awake()
    {
        if (agent == null)
        {
            gameObject.AddComponent<NavMeshAgent>();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = transform.GetChild(1).GetComponent<Animator>();
        isShotHash = Animator.StringToHash("isShot");

    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        LookAtPlayer();
        Patrolling();
        if (inRange && Time.time > nextFire)
        {
            Attack();
        }

    }
    private void Patrolling()
    {
        if (Physics.CheckSphere(transform.position, attackRange, playerMask))
        {
            inRange = true;
        }
        else
        {
            inRange = false;

        }
    }
    private void Attack()
    {
        bool isShot = animator.GetBool(isShotHash);
        animator.SetBool("isShot", true);

        nextFire = Time.time + fireRate;
        GameObject instantiatedGameObject = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.identity);
        instantiatedGameObject.GetComponent<ProjectileController>().InitShooter(gameObject);
        instantiatedGameObject.GetComponent<ProjectileController>().penetrateable = isCanPassThru;
        instantiatedGameObject.GetComponent<ProjectileController>().force = projectileSpeed;
        instantiatedGameObject.GetComponent<ProjectileController>().damage = damage;



    }
    private void LookAtPlayer()
    {
        if (transform.position.z > player.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
