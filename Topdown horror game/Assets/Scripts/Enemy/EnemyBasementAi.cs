using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    notAcitve,
    movingDownStairs,
    movingUpStairs,
    isDownstairs,
    checkingDoor
}

public enum DoorState
{
    closed,
    open
}

public class EnemyBasementAi : MonoBehaviour
{
    [Header("State that the enemy is currently in")]
    public EnemyState enemyState;

    [Header("If the enemy opened or left the door closed")]
    public DoorState doorState;

    [Header("The start and end point of the enemy")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [Header("AudioClips and Audio source of the enemy")]
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource enemyAudioSource;

    [Header("the speed at which the enemy moves")]
    [SerializeField] private float speed;
    float speedPerTile;

    void Start()
    {
        enemyState = EnemyState.notAcitve;
    }

    void Update()
    {
        if(enemyState == EnemyState.notAcitve && enemyState != EnemyState.isDownstairs)
        {
            StartCoroutine(DelayDown(0));
        }

        if(enemyState == EnemyState.isDownstairs && enemyState != EnemyState.notAcitve)
        {
            ChanceToOpenDoorCheck();
            StartCoroutine(DelayUp(0));
        }

        if(enemyState == EnemyState.checkingDoor && doorState == DoorState.open)
        {
            StartCoroutine(DoorDelay(0));
        }
    }

    //moves the enemy downstairs
    private void MoveEnemyDownStairs()
    {
        speedPerTile = speed * Time.deltaTime;

        enemyState = EnemyState.movingDownStairs;

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, endPoint.position, speedPerTile);

        if(gameObject.transform.position.x == endPoint.position.x)
        {
            enemyState = EnemyState.isDownstairs;
        }
    }

    //moves the enemy upstairs
    private void MoveEnemyUpstairs()
    {
        speedPerTile = speed * Time.deltaTime;

        enemyState = EnemyState.movingUpStairs;

        if(enemyState == EnemyState.movingUpStairs)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, startPoint.position, speedPerTile);
        }

        if(gameObject.transform.position.x == startPoint.position.x)
        {
            enemyState = EnemyState.notAcitve;
        }
    }

    //checks to see if the enemy will open the door or not
    private void ChanceToOpenDoorCheck()
    {
        int chance;
        chance = Random.Range(0, 5);

            if(chance == 3)
            {
                enemyState = EnemyState.checkingDoor;
                doorState = DoorState.open;
            }
    }

    //randomly delays how long the enemy will wait to go upstairs
    private IEnumerator DelayUp(float time)
    {
        time = Random.Range(3f, 7f);
        yield return new WaitForSeconds(time);

        MoveEnemyUpstairs();
    }

    //randomly delays how long the enemy will wait to go downstairs
    private IEnumerator DelayDown(float time)
    {
        time = Random.Range(5f, 10f);
        yield return new WaitForSeconds(time);

        MoveEnemyDownStairs();
    }

    private IEnumerator DoorDelay(float time)
    {
        time = Random.Range(3f, 6f);
        yield return new WaitForSeconds(time);

        doorState = DoorState.closed;
        MoveEnemyUpstairs();
    }

}
