using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [Header("Jump System")]
    [SerializeField] int jump;
    [SerializeField] float fallMultiplier;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    Vector2 vecGravity;

    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;

    bool isjumping;
    float jumpCounter;
    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isjumping = true;
            jumpCounter = 0;
        }

        if (rb.velocity.y > 0 && isjumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isjumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isjumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        isJumping();
    }
    public bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.89f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    void isJumping()
    {
        if (isGrounded())
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }
    }
}
