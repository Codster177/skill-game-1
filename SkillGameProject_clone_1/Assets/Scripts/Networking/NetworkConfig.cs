using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Example;
using FishNet.Object;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class NetworkConfig : MonoBehaviour
{
    private Tugboat tugboatConfig;
    private NetworkHudCanvases networkHudCanvases;
    void Awake()
    {
        tugboatConfig = GetComponent<Tugboat>();
        networkHudCanvases = GetComponentInChildren<NetworkHudCanvases>();
    }

    void Start()
    {
        TestingManager();
    }
    
    public void TestingManager()
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

    public void ChangePort(ushort newPort)
    {
        tugboatConfig.SetPort(newPort);
    }

    public void StartClient()
    {
        networkHudCanvases.OnClick_Client();
    }
    
}
