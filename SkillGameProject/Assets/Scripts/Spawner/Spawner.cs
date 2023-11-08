using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private Vector2 leftBottomBounds;
    [SerializeField]
    private Vector2 rightTopBounds;
    [SerializeField]
    private float spawnRate = 1f;
    private bool spawnBool = true;
    void Update()
    {
        if (spawnBool)
        {
            StartCoroutine(SpawnThing());
        }
    }

    IEnumerator SpawnThing()
    {
        spawnBool = false;
        Instantiate(Enemy, new Vector3(UnityEngine.Random.Range(leftBottomBounds.x, rightTopBounds.x), UnityEngine.Random.Range(leftBottomBounds.y, rightTopBounds.y), 0f), quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        spawnBool = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3((rightTopBounds.x + leftBottomBounds.x)/2, (rightTopBounds.y + leftBottomBounds.y)/2, 0f), new Vector3(rightTopBounds.x - leftBottomBounds.x, rightTopBounds.y - leftBottomBounds.y, 0f));
    }
}