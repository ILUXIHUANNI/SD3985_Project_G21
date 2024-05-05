using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float speed;
    Vector2 move;
    bool facingRight = false;
    private void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        transform.Translate(move * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        { 
            //if (!Input.GetButton("Horizontal"))
                collision.transform.Translate(move * speed);
        }
    }

    void Move()
    {
        if (transform.position.x > endPoint.position.x)
        {
            facingRight = false;
        }
        else if (transform.position.x < startPoint.position.x)
        {
            facingRight = true;
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
}
