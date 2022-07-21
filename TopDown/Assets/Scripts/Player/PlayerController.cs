using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip swordSound;
    [SerializeField] float speed;
    private Animator animator;
    Rigidbody2D rb;
    private float attackTime = .5f;
    private float attackCounter = .5f;
    private bool isAttacking;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float x = SimpleInput.GetAxisRaw("Horizontal");
        //x *= speed * Time.deltaTime;
        float y = SimpleInput.GetAxisRaw("Vertical");
        //y *= speed * Time.deltaTime;
        //rb.velocity = new Vector2(SimpleInput.GetAxisRaw("Horizontal"), SimpleInput.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        rb.velocity = new Vector2(x, y);

        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        //rb.velocity = new Vector2(x, y) * speed * Time.deltaTime;
        rb.velocity = new Vector2(x * speed, y * speed);

        if (x != 0 || y != 0)
        {
            animator.SetFloat("lastMoveX", SimpleInput.GetAxis("Horizontal"));
            animator.SetFloat("lastMoveY", SimpleInput.GetAxis("Vertical"));
        }

        //if (SimpleInput.GetAxis("Horizontal") < 1 || SimpleInput.GetAxis("Horizontal") > -1 || SimpleInput.GetAxis("Vertical") < 1 || SimpleInput.GetAxis("Vertical") > -1)
        //{
        //    animator.SetFloat("lastMoveX", SimpleInput.GetAxis("Horizontal"));
        //    animator.SetFloat("lastMoveY", SimpleInput.GetAxis("Vertical"));
        //}


        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }

        }
        if (SimpleInput.GetKeyDown(KeyCode.J))
        {
            SoundEffect.instance.PlaySound(swordSound);
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }


}
