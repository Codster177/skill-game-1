using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class StartGameButton : NetworkBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private GameClock gameClock;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            this.enabled = false;
        }
    }
    void Start()
    {
        startButton.onClick.AddListener(StartButtonClicked);
        startButton.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (gameClock.getGameActive())
        {
            startButton.gameObject.SetActive(false);
        }
        else
        {
            startButton.gameObject.SetActive(true);
        }
    }

    void StartButtonClicked()
    {
        gameClock.startGameActive(gameClock);
    }
}
