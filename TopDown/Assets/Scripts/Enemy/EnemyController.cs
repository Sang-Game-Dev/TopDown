using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Private")]

    private Animator animator;
    private Transform target;
    [SerializeField] float speed;
    [SerializeField] float maxRange;
    [SerializeField] float minRange;

    [Header("Public")]
    public Transform homePos; 

    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(target.position,transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >=minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

        
        
    }

    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", target.position.x-transform.position.x);
        animator.SetFloat("moveY", target.position.y-transform.position.y); 
        
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
    }

    public void GoHome()
    {
        animator.SetFloat("moveX", homePos.position.x - transform.position.x);
        animator.SetFloat("moveY", homePos.position.y - transform.position.y);   
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
            animator.SetBool("isMoving", false);
    }

   
}
