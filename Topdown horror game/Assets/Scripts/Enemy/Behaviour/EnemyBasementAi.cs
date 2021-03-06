﻿using System.Collections;
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

public enum BasementDoor
{
    closed,
    open
}

public class EnemyBasementAi :  MonoBehaviour
{
    [Header("keeps track of the behaviour of the enemy")]
    public EnemyBehaviour EnemyBehaviour;

    [Header("tracks if the door is open or closed")]
    public BasementDoor basementDoor;

    [Header("The start and end point of the enemy")]
    [SerializeField] private Transform startPoint = null;
    [SerializeField] private Transform endPoint = null;

    [Header("Timers and delays")]
    [SerializeField] private float moveDownDelay = 0.0f;
    [SerializeField] private float moveUpDelay = 0.0f;

    [Header("Set the value of how long the enemy takes to walk down the stairs")]
    [Range(0, 25)]
    [SerializeField] private float minValueDownstairs = 0.0f;
    [Range(0, 25)]
    [SerializeField] private float maxValueDownstairs = 0.0f;

    [Header("Set the value of how long the enemy takes to walk up the stairs")]
    [Range(0, 15)]
    [SerializeField] private float minValueUpstairs = 0.0f;
    [Range(0, 15)]
    [SerializeField] private float maxValueUpstairs = 0.0f;

    private float moveUpMax = 5.0f;
    private float moveUpMin = 0.5f;

    private float moveDownMax = 5.0f;
    private float moveDownMin = 0.5f;

    private int randomCall = 1;

    private int audioChance = 1;

    private int chanceToOpenDoor;

    [Header("AudioClips and Audio source of the enemy")]
    [SerializeField] private AudioClip[] audioClips = null;
    [SerializeField] private AudioSource enemyAudioSource = null;

    void Start()
    {
        gameObject.transform.position = startPoint.position;

        moveDownDelay = Random.Range(7.5f, 10.0f);
    }

    void Update()
    {
        //starts the delay for when the player is upstairs
        if (EnemyBehaviour == EnemyBehaviour.isUpstairs)
        {
            DelayDown();
        }

        //starts the delay for when the player is Downstairs
        if (EnemyBehaviour == EnemyBehaviour.isDownstairs)
        {
            CheckOnPlayer();
        }

        //checks if the the timer is equal to 0 or under and if the position is the same as the starting position
        if (moveDownDelay <= 0.0f && gameObject.transform.position == startPoint.position)
        {
            MoveEnemyDownStairs();

            moveDownDelay = moveDownMax;

            randomCall = 1;
            audioChance = 1;
        }

        //checks if the the timer is equal to 0 or under and if the position is the same as the end position
        if (moveUpDelay <= 0.0f && gameObject.transform.position == endPoint.position)
        {
            MoveEnemyUpstairs();

            moveUpDelay = moveUpMax;

            randomCall = 1;
            audioChance = 1;
        }
    }

    //moves the enemy downstairs
    private void MoveEnemyDownStairs()
    {
        if(EnemyBehaviour == EnemyBehaviour.isUpstairs)
        {
            enemyAudioSource.clip = audioClips[0];

            if (!enemyAudioSource.isPlaying)
            {
                enemyAudioSource.Play();
                audioChance = 0;
            }

            gameObject.transform.position = endPoint.position;

            EnemyBehaviour = EnemyBehaviour.isDownstairs;
        }
    }

    //moves the enemy upstairs and plays the audio for going upstairs
    private void MoveEnemyUpstairs()
    { 
        if(EnemyBehaviour == EnemyBehaviour.isDownstairs)
        {
            enemyAudioSource.clip = audioClips[1];

            if (!enemyAudioSource.isPlaying)
            {
                enemyAudioSource.Play();
                audioChance = 0;
            }

            gameObject.transform.position = startPoint.position;

            basementDoor = BasementDoor.closed;
            EnemyBehaviour = EnemyBehaviour.isUpstairs;
        }
    }

    //randomly delays how long the enemy will wait to go upstairs
    private void DelayUp()
    {
        if(randomCall == 1)
        {
            moveUpDelay = Random.Range(minValueUpstairs, maxValueUpstairs);

            randomCall = 0;
        }

        moveUpDelay = moveUpDelay - 1 * Time.deltaTime;

    }

    //randomly delays how long the enemy will wait to go downstairs
    private void DelayDown()
    {
        if (!enemyAudioSource.isPlaying)
        {
            if (randomCall == 1)
            {
                moveDownDelay = Random.Range(minValueDownstairs, maxValueDownstairs);

                randomCall = 0;
            }

            moveDownDelay = moveDownDelay - 1 * Time.deltaTime;
        }
    }

    //gives the enemy a chance to open the door and check on the player and plays the audio first
    private void CheckOnPlayer()
    {
        if (!enemyAudioSource.isPlaying)
        {
            if (randomCall == 1)
            {
                chanceToOpenDoor = Random.Range(1, 3);
            }

            OpenOrClosed();
        }
    }

    private void OpenOrClosed()
    {
        if(chanceToOpenDoor <= 1)
        {
            basementDoor = BasementDoor.closed;

            DelayUp();
        }
        else if(chanceToOpenDoor == 2)
        {
            basementDoor = BasementDoor.open;

            DelayUp();
        }
    }
}
