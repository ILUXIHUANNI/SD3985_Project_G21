using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMonsterController : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float speed;
    Vector2 move;
    Vector2 lookDirection = new Vector2(1, 0);
    bool facingRight = false;
    Animator animator;

    [SerializeField] bool isDeath = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        flip();
    }

    void FixedUpdate()
    {
        transform.Translate(move * speed);
    }

    void Movement()
    {
        if (transform.position.x < endPoint.position.x)
        {
            facingRight = true;
        }
        else if (transform.position.x > startPoint.position.x)
        {
            facingRight = false;
        }
        if (facingRight)
        {
            move = transform.right;
        }
        else
        {
            move = -transform.right;
        }
    }
    void flip()
    {
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("LookX", lookDirection.x);
    }
}
