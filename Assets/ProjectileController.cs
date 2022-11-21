using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;
    private Vector3 direction;
    private GameObject shooter;
    [HideInInspector] public float force;
    [HideInInspector] public bool penetrateable;
    [HideInInspector] public float damage;
    [HideInInspector] public bool isMelee;
    public GameObject particle;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!isMelee)
        {
            direction = player.position - transform.position;
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }
    private void Start()
    {
        if (!isMelee)
        {
            rb.AddForce(direction.normalized * force, ForceMode.Impulse);
            GetComponent<Collider>().isTrigger = penetrateable;
        }

    }

    private void Update()
    {
        if (!isMelee)
        {
            float distance = Vector3.Distance(transform.position, shooter.transform.position);
            if (distance >= shooter.GetComponent<RangeEnemy>().maxProjectileDistance)
            {
                Destroy(gameObject);
            }
            Destroy(gameObject, 4f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
    public void InitShooter(GameObject go)
    {
        shooter = go;
    }
    private void OnDestroy()
    {
        if (!isMelee)
        {
            if (particle != null)
            {
                GameObject instantiated = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(instantiated, 1);
            }
        }
    }
}