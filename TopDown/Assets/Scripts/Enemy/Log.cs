using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Log : Enemy
{
    private Rigidbody2D rb;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;

    private void Start()
    {
        currentState = EnemyState.idle;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= chaseRadius && Vector3.Distance(target.transform.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
