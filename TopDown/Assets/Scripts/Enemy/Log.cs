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
                Vector3 temp = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                rb.MovePosition(temp);
                
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x -difference.x, transform.position.y - difference.y);
        }
    }
}
