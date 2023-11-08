using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 5f;
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
}
