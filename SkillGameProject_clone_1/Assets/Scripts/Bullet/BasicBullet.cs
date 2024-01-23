using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class BasicBullet : NetworkBehaviour
{
    public float bulletSpeed = 50f;
    [SerializeField]
    private Renderer bulletRend;
    [SerializeField]
    private GameObject EnemyDeath;
    [SerializeField]
    private bool bulletsCollide;
    private float startTime;
    private bool fireDelay = false;

    // Update is called once per frame
    void Start()
    {
        startTime = Time.time;
        StartCoroutine(FireDelayer());
    }

    void FixedUpdate()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (((Time.time - startTime) >= 20f) && (!base.IsServer))
        {
            Destroy(gameObject);
        }
        if (fireDelay && (!base.IsServer))
        {
            if (!bulletRend.isVisible)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tags.enemyTag))
        {
            if (base.IsServer)
            {
                GameObject deathParticles = Instantiate(EnemyDeath, collider.gameObject.transform.position, quaternion.identity);
                ServerManager.Spawn(deathParticles);
            }
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag(tags.bulletTag))
        {
            if (!bulletsCollide)
            {
                return;
            }
        }
        Destroy(gameObject);
    }
    IEnumerator FireDelayer()
    {
        yield return new WaitForSeconds(0.5f);
        fireDelay = true;
    }

}
