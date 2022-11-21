using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // get enemy health
        }

    }


    IEnumerator slefDestro()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
