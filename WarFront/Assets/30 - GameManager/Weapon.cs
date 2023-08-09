using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WarFront/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Gun Attributes")]
    public string gunName;
    public int magSize;
    public int shotsPerSec;
    public float timeToReLoad;
}
