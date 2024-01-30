using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class ActiveUpdate : NetworkBehaviour
{
    [field: SyncVar] private bool commonGameActive {get; [ServerRpc] set;}
    void Awake()
    {
        commonGameActive = GameManager.publicGameManager.getGameActive();
    }
    public void startCommonGameActive()
    {
        commonGameActive = true;
        GameManager.publicGameManager.startGameActive();
    }
    
    void Update()
    {
        if (!GameManager.publicGameManager.getGameActive())
        {
            commonGameActive = false;
        }
    }
}
