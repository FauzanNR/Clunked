using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerScript : MonoBehaviour
{
    public float health;
    public GameObject particle;
    public float damagedDuration;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            var damageObject = other.GetComponent<ProjectileController>();
            if (damageObject != null)
            {
                health -= damageObject.damage;
                Destroy(other);
                if (!other.GetComponent<ProjectileController>().isMelee)
                {
                    GameObject damagedFX = Instantiate(particle, transform.position, Quaternion.identity);
                    Destroy(damagedFX, damagedDuration);

                }
            }

        }
    }
}
