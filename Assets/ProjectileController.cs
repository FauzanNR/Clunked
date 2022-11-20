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


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.position - transform.position;
        rb = gameObject.AddComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        GetComponent<Collider>().isTrigger = penetrateable;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, shooter.transform.position);
        if (distance >= shooter.GetComponent<RangeEnemy>().maxProjectileDistance)
        {
            Destroy(gameObject);
        }
    }
    public void InitShooter(GameObject go)
    {
        shooter = go;
    }
}