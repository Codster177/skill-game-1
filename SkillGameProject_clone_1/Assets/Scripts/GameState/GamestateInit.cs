using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamestateInit : MonoBehaviour
{
    [SerializeField]
    private LocalManager currentGameManager;

    void Awake()
    {
        LocalManager.publicLocalManager = currentGameManager;
    }
}
