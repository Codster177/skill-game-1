using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestConsole : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField consoleInput;
    [SerializeField]
    private NetworkConfig netConfig;

    void Awake()
    {
        consoleInput.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            toggleConsole();
        }
        if (!consoleInput.gameObject.activeSelf)
        {
            return;
        }
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("Enter Hit");
            readConsole();
        }
    }
    void toggleConsole()
    {
        if (consoleInput.gameObject.activeSelf)
        {
            consoleInput.gameObject.SetActive(false);
        }
        else
        {
            consoleInput.gameObject.SetActive(true);
        }
    }
    void readConsole()
    {
        CustCommands command = new CustCommands(consoleInput.text);
        consoleInput.text = "";
        
        switch (command.getCommandInt())
        {
            case 0:
                return;
            case 1:
                GameManager.publicGameManager.ServerAddress = command.commandIP();
                break;
            case 2:
                GameManager.publicGameManager.testing = command.commandTesting();
                break;
            default:
                return;
        }
    }
}
