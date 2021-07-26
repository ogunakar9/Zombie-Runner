using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ammoSlot.ReduceCurrentAmmo();
            PlayMuzzleFlash();
            ProcessRaycast();
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CrateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }

            target.TakeDamage(damage);
            // call a method on EnemyHealth that decreases the enemy's health
        }
        else
        {
            return;
        }
    }

    void CrateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
