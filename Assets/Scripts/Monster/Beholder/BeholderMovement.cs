using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeholderMovement : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform player;
    [SerializeField] float speed;
    Vector2 move;
    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 previousPos;
    Animator animator;

    NavMeshAgent navMeshAgent;
    bool inPath = true;
    bool touchStart = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    void Update()
    {
        Movement(LightDetection.instance.CheckIfCanSee(this.gameObject));
        previousPos = transform.position;
        flip();
    }

    void FixedUpdate()
    {
        //transform.Translate(move * speed);
    }

    void Movement(bool isDetected)
    {
        float disStart = (transform.position - startPoint.position).magnitude;
        float disEnd = (transform.position - endPoint.position).magnitude;
        if (isDetected)
        {
            navMeshAgent.destination = player.position;
            transform.position = new Vector2(transform.position.x, transform.position.y);
            move = new Vector2(transform.position.x, transform.position.y) - previousPos;
            inPath = false;
        }
        else
        {
            if (inPath) 
            {
                if (disStart <= 2)
                {
                    touchStart = false;
                }
                if (disEnd <= 2)
                {
                    touchStart = true;
                }
                if (touchStart)
                {
                    navMeshAgent.destination = startPoint.position;
                    transform.position = new Vector2(transform.position.x, transform.position.y);
                    move = new Vector2(transform.position.x, transform.position.y) - previousPos;
                }
                else
                {
                    navMeshAgent.destination = endPoint.position;
                    transform.position = new Vector2(transform.position.x, transform.position.y);
                    move = new Vector2(transform.position.x, transform.position.y) - previousPos;
                }
                    
            }
            else 
            {
                if (disStart < disEnd)
                {
                    navMeshAgent.destination = startPoint.position;
                    transform.position = new Vector2(transform.position.x, transform.position.y);
                    move = new Vector2(transform.position.x, transform.position.y) - previousPos;
                }
                else
                {
                    navMeshAgent.destination = endPoint.position;
                    transform.position = new Vector2(transform.position.x, transform.position.y);
                    move = new Vector2(transform.position.x, transform.position.y) - previousPos;
                }
                if (disStart <= 2)
                    inPath = true;
                if (disEnd <= 2)
                    inPath = true;
            }
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

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }
}
