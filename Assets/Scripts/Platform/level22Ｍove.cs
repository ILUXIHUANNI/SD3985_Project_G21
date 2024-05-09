using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level22Ｍove : MonoBehaviour
{
    [SerializeField] level22StartMove startMove;
    [SerializeField] float speed;

    private void Update()
    {
        if (startMove.startMove())
        {
            Movement();
        }
    }

    void Movement()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
