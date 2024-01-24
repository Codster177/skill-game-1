using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using FishNet.Object;
using UnityEngine;

public class EnemyMovement : NetworkBehaviour
{
    [SerializeField]
    private float enemySpeed = 5f;
    [SerializeField]
    private GameObject EnemyDeath;
    private float startTime;

    // Update is called once per frame
    void Start()
    {
        startTime = Time.time;
    }
    void FixedUpdate()
    {
        transform.position += -transform.up * enemySpeed * Time.deltaTime;
    }
    void Update()
    {
        if ((Time.time - startTime) >= 20f)
        {
            Destroy(gameObject);
        }
    }

    public void onDeath()
    {
        GameObject deathParticles = Instantiate(EnemyDeath, transform.position, quaternion.identity);
        ServerManager.Spawn(deathParticles);
        Destroy(gameObject);
    }
}
