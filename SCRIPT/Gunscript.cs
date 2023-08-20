using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;

    public Camera fpsCam;

    void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
