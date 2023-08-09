using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "WarFront/GameData")]
public class GameData : ScriptableObject
{
    [Header("Player Attributes")]
    public int playerSpeed;
}
