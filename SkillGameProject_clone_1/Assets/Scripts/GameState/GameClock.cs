using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class GameClock : NetworkBehaviour
{
    [SerializeField] private TMP_Text clockText;
    [SyncVar] private float startTime;
    private GameObject clockBackground;

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
        startTime = -1f;
        clockBackground = clockText.gameObject.transform.parent.gameObject;
        clockText.gameObject.SetActive(false);
        clockBackground.SetActive(false);
    }

    void Update()
    {
        UpdateGameActive(this);
    }

    public bool getGameActive()
    {
        if (startTime == -1f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    [ServerRpc]
    public void UpdateGameActive(GameClock script)
    {
        if (script.startTime == -1f)
        {
            return;
        }
        if ((Time.timeSinceLevelLoad - script.startTime) >= 30f)
        {
            clockStop(script);
        }
        clockRun(script);

    }

    [ServerRpc]
    private void clockStop(GameClock script)
    {
        script.startTime = -1f;
        script.clockText.gameObject.SetActive(false);
        script.clockBackground.SetActive(false);
        startTime = -1f;
    }

    [ServerRpc]
    private void clockRun(GameClock script)
    {
        script.clockText.gameObject.SetActive(true);
        script.clockBackground.SetActive(true);
        float timeLeft = Time.timeSinceLevelLoad - script.startTime;
        timeLeft = Convert.ToSingle(System.Math.Round(timeLeft, 0));
        clockText.text = (30 - timeLeft) + " seconds left";
    }

    [ServerRpc]
    public void startGameActive(GameClock script)
    {
        script.startTime = Time.timeSinceLevelLoad;
    }
}