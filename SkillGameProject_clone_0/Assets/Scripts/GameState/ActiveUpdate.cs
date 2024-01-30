using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class ActiveUpdate : NetworkBehaviour
{
    [SyncVar] 
    private bool commonGameActive = false;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            this.enabled = false;
        }
    }
    void Awake()
    {
        commonGameActive = GameManager.publicGameManager.getGameActive();
    }
    public void startCommonGameActive()
    {
        updateCommonGameActive(true);
    }
    
    public void stopCommonGameActive()
    {
        updateCommonGameActive(false);
    }

    void updateCommonGameActive(bool status)
    {
        commonGameActive = status;
    }

    [ServerRpc]
    public void UpdateGameActive(ActiveUpdate script, bool gameActiveStatus)
    {
        script.updateCommonGameActive(gameActiveStatus);
        if (gameActiveStatus)
        {
            GameManager.publicGameManager.startGameActive();
        }
        else
        {
            GameManager.publicGameManager.resetGameActive();
        }
    }
}
