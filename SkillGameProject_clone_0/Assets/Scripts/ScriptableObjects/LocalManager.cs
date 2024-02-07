using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalManager", menuName = "GameState/LocalManager")]
public class LocalManager : ScriptableObject
{
    public static LocalManager publicLocalManager;
    public string ServerAddress;
    public bool testing;

}
