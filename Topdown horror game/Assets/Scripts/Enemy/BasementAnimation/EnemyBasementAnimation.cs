using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasementAnimation : MonoBehaviour
{
    private EnemyBasementAi enemyBasementAi = null;

    private Animator animator;

    void Start()
    {
        enemyBasementAi = FindObjectOfType<EnemyBasementAi>();


        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimatorValues();

    }

    private void SetAnimatorValues()
    {
        if (animator != null)
        {
            animator.SetInteger("State", (int)enemyBasementAi.basementDoor);
        }
    }
}
