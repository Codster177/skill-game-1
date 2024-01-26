using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameState/GameManager")]
public class GameManager : ScriptableObject
{
    public static GameManager publicGameManager;
    public string ServerAddress;
    public bool testing;
    private bool gameActive;

    public bool getGameActive()
    {
        return gameActive;
    }
    public void startGameActive()
    {
        gameActive = true;
    }

    public void resetGameActive()
    {
        gameActive = false;
    }

}
