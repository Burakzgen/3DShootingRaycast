using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range, damage;
    public Camera fpsCam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            //Debug.Log(hitInfo.transform.name);
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
