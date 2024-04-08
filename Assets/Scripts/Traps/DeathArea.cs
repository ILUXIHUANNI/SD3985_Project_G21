using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public static bool isDeath = false; 
    Animator animator;
    Animator[] gameover; 
    float time = 1.5f;
    float timer = 0;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        gameover = GameObject.FindGameObjectWithTag("GameOver").GetComponentsInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDeath = true;
            animator.SetTrigger("Death");
        }
    }

    private void Update()
    {
        if (isDeath)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                for (int i = 0; i < gameover.Length; i++)
                {
                    gameover[i].SetTrigger("Die");
                }
            }
        }
    }
}
