using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float fireRate = 5f;
    [SerializeField]
    private ParticleSystem shotParticles;
    private bool fired = false;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!fired)
            {
                Shoot();
                FireRate();
            }
        }
        else
        {
            if (fireRate == 0f)
            {
                fired = false;
            }
        }
    }
    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject shotBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        shotParticles.Play();
    }
    void FireRate()
    {
        if (fireRate == 0f)
        {
            fired = true;
        }
        else
        {
            StartCoroutine(WaitBetweenShots());
        }
    }
    IEnumerator WaitBetweenShots()
    {
        fired = true;
        yield return new WaitForSeconds(fireRate);
        fired = false;
    }
}
