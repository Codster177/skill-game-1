using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamestateInit : MonoBehaviour
{
    [SerializeField]
    private GameManager currentGameManager;

    void Awake()
    {
        GameManager.publicGameManager = currentGameManager;
    }
}
