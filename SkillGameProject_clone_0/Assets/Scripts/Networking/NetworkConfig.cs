using System.Collections;
using System.Collections.Generic;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class NetworkConfig : MonoBehaviour
{
    private Tugboat tugboatConfig;
    void Awake()
    {
        tugboatConfig = GetComponent<Tugboat>();
    }
    void Start()
    {
        if (GameManager.publicGameManager.testing == true)
        {
            tugboatConfig.SetClientAddress("localhost");
        }
        else
        {
            tugboatConfig.SetClientAddress(GameManager.publicGameManager.ServerAddress);
        }
    }
}
