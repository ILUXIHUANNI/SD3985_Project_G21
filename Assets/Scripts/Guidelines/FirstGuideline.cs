using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGuideline : MonoBehaviour
{
    //[SerializeField] SpriteRenderer sprite;
    SpriteRenderer[] spriteList;
    private void Awake()
    {
        spriteList = GetComponentsInChildren<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < spriteList.Length; i++)
            {
                spriteList[i].enabled = true;
            }
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.enabled = false;
        }
    }*/
}
