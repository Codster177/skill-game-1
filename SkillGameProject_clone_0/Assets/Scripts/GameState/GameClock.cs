using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TMP_Text clockText;
    private ActiveUpdate activeUpdate;
    private float startTime;
    private GameObject clockBackground;

    void Awake()
    {
        activeUpdate = gameObject.GetComponent<ActiveUpdate>();
        startTime = -1f;
        clockBackground = clockText.gameObject.transform.parent.gameObject;
        clockText.gameObject.SetActive(false);
        clockBackground.SetActive(false);
    }
    public void startGameActive()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if (startTime == -1f)
        {
            return;
        }
        if (!GameManager.publicGameManager.getGameActive())
        {
            clockText.gameObject.SetActive(false);
            clockBackground.SetActive(false);
            startTime = -1f;
            return;
        }
        if ((Time.timeSinceLevelLoad - startTime) >= 30f)
        {
            activeUpdate.stopCommonGameActive();
        }
        clockText.gameObject.SetActive(true);
        clockBackground.SetActive(true);
        float timeLeft = Time.timeSinceLevelLoad - startTime;
        timeLeft = Convert.ToSingle(System.Math.Round(timeLeft, 0));
        clockText.text = (30-timeLeft) + " seconds left";
    }

}
