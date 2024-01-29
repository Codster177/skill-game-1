using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
    [SerializeField] private String lobbyName;
    [SerializeField] private ushort portNumber;
    [SerializeField] private NetworkConfig networkConfig;
    [SerializeField] private TMP_Text lobbyNameText;
    [SerializeField] private GameObject lobbiesObject;
    private Button joinButton;

    void Awake()
    {
        joinButton = GetComponentInChildren<Button>();
        joinButton.onClick.AddListener(connectToLobby);
        lobbyNameText.text = lobbyName;
    }

    void connectToLobby()
    {
        networkConfig.ChangePort(portNumber);
        networkConfig.StartClient();
        lobbiesObject.SetActive(false);
    }
}
