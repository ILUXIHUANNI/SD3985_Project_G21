using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementUP : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float speed;
    Vector2 move;
    bool facingUp = false;
    private void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        transform.Translate(move * speed);
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        //if (!Input.GetButton("Horizontal"))
    //        collision.transform.Translate(move * speed);
    //    }
    //}

    void Move()
    {
        if (transform.position.y > endPoint.position.y)
        {
            facingUp = false;
        }
        else if (transform.position.y < startPoint.position.y)
        {
            facingUp = true;
        }
        if (facingUp)
        {
            move = transform.up;
        }
        else
        {
            move = -transform.up;
        }
    }
}
