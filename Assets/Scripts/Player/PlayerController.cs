using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 move;
    Vector2 lookDirection = new Vector2(1, 0);

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        flip();
        isRunning();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(move * speed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(move.x *speed, rb.velocity.y);
    }


    void flip()
    {
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
    }

    void isRunning()
    {
        if (Input.GetButton("Horizontal"))
            animator.SetBool("run",true);
        else
            animator.SetBool("run", false);
    }

    private void Movement()
    {
        if (DeathArea.isDeath)
            move = new Vector2(0, 0);
        else
            move = new Vector2(Input.GetAxis("Horizontal"), 0);
    }
}
