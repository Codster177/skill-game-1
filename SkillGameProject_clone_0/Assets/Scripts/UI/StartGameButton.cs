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
    private ActiveUpdate activeUpdate;
    void Start()
    {
        startButton.onClick.AddListener(StartButtonClicked);
        startButton.gameObject.SetActive(false);

        activeUpdate = GetComponent<ActiveUpdate>();
    }
    
    void Update()
    {
        if (GameManager.publicGameManager.getGameActive())
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
        activeUpdate.startCommonGameActive();
        gameClock.startGameActive();
    }
}
