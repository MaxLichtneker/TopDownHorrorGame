using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyBehaviour
{
    notAcitve,
    movingDownStairs,
    movingUpStairs,
    isUpstairs,
    isDownstairs,
    checkingDoor
}

public enum PlayerBehaviour
{
    sitting,
    standing
}

public enum BasementDoor
{
    closed,
    open
}

public class Behaviours : MonoBehaviour
{
    [Header("keeps track of the behaviour of the enemy")]
    public EnemyBehaviour EnemyBehaviour;

    [Header("keeps track if the player is still sitting in the chair or not")]
    public PlayerBehaviour playerBehaviour;
    
    [Header("tracks if the door is open or closed")]
    public BasementDoor basementDoor;
}
