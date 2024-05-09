using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level22StartMove : MonoBehaviour
{
    bool start;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            start = true;
            boxCollider.enabled = false;
        }
    }

    public bool startMove()
    {
        return start;
    }
}
