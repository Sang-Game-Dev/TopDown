using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip swordSound;
    [SerializeField] float speed;
    private Animator animator;
    Rigidbody2D rb;
    private float attackTime = .2f;
    private float attackCounter = .2f;
    private bool isAttacking;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(SimpleInput.GetAxisRaw("Horizontal"), SimpleInput.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        if (SimpleInput.GetAxisRaw("Horizontal") == 1 || SimpleInput.GetAxisRaw("Horizontal") == -1 || SimpleInput.GetAxisRaw("Vertical") == 1 || SimpleInput.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", SimpleInput.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", SimpleInput.GetAxisRaw("Vertical"));
        }

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
