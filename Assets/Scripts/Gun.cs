using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range, damage, fireRate, impactForce;
    public Camera fpsCam;
    public ParticleSystem shootFlash;
    private float nextTimeToFire = 0;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        shootFlash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            //Debug.Log(hitInfo.transform.name);
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }
            if (hitInfo.collider.CompareTag("Target"))
            {
                hitInfo.transform.localScale += Vector3.one * 1.5f;
            }
        }
    }
}
