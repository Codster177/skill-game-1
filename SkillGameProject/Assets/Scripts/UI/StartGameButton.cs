using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Connection;
using FishNet.Object;

public class StartGameButton : NetworkBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private GameClock gameClock;
    void Start()
    {
        startButton.onClick.AddListener(StartButtonClicked);
    }
    
    void Update()
    {
        if (GameManager.publicGameManager.getGameActive() || (!base.IsClient))
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
        GameManager.publicGameManager.startGameActive();
        gameClock.startGameActive();
    }


}
