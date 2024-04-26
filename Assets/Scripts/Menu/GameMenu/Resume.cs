using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Resume : MonoBehaviour
{
    [SerializeField] Canvas close;
    public void Back() 
    {
        close.enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setSpeed(7);
    }
}
