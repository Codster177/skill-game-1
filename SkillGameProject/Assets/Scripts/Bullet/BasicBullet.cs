using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float bulletSpeed = 50f;
    private float startTime;

    // Update is called once per frame
    void Start()
    {
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void Update()
    {
        if ((Time.time - startTime) >= 20f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit Something");
        if (collider.gameObject.CompareTag(tags.enemyTag))
        {
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}
