using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    
    [SerializeField]
    private float killTime = 3f;
    void Start()
    {
        StartCoroutine(KillSelf());
    }
    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(killTime);
    }
}
