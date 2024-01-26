using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerStart : MonoBehaviour
{
    [SerializeField] private bool serverBuild = false;
    private NetworkConfig networkConfig;
    // Start is called before the first frame update
    void Awake()
    {
        networkConfig = GetComponent<NetworkConfig>();
        if (!serverBuild)
        {
            return;
        }
        Console.WriteLine("Enter port for server.");
        string portResponse = Console.ReadLine();
        ushort value = 7700;
        ushort.TryParse(portResponse, out value);
        networkConfig.ChangePort(value);
    }
}
