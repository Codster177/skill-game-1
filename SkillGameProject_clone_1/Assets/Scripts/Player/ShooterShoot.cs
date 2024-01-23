using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

public class ShooterShoot : NetworkBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float fireRate = 5f;
    [SerializeField]
    private ParticleSystem shotParticles;
    [SerializeField]
    private ShooterMove thisMovement;
    private bool fired = false;

    void Start()
    {
        ServerManager.Spawn(gameObject);
        if (base.IsServer)
        {
            gameObject.GetComponent<ShooterShoot>().enabled = false;
            thisMovement.enabled = false;
        }
    }

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
        ServerManager.Spawn(shotBullet);
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

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            gameObject.GetComponent<ShooterShoot>().enabled = false;
            thisMovement.enabled = false;
        }
    }
}
