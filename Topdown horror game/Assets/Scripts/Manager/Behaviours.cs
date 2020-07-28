using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Behaviours : MonoBehaviour
{

    private EnemyBasementAi enemyBasementAi = null;
    private GetOutOfChair getOutOfChair = null;

    [Header("keeps track of the behaviour of the enemy")]
    [SerializeField]private EnemyBehaviour enemy;

    [Header("keeps track if the player is still sitting in the chair or not")]
    public PlayerBehaviour player;

    [Header("tracks if the door is open or closed")]
    public BasementDoor door;

    [Header("Panel that activates when player dies")]
    [SerializeField] private GameObject deathScreenPanel = null;

    private void Start()
    {
        enemyBasementAi = FindObjectOfType<EnemyBasementAi>();

        getOutOfChair = FindObjectOfType<GetOutOfChair>();
    }

    private void Update()
    {
        //sets the enum to the enum of the enemy
        enemy = enemyBasementAi.EnemyBehaviour;

        //sets the enum of the basementdoor to the gamemanager
        door = enemyBasementAi.basementDoor;

        //sets enum of the player to the playerbehaviour enum
        player = getOutOfChair.playerBehaviour;

        CheckIfPLayerIsDead();
    }

    private void CheckIfPLayerIsDead()
    {
        //checks if the basement door is open and if the player is standing
        if(door == BasementDoor.open && player == PlayerBehaviour.standing)
        {
            //turns on the deathscreenpanel
            deathScreenPanel.SetActive(true);

            //sets the game time to 0
            Time.timeScale = 0.0f;
        }
    }

}
