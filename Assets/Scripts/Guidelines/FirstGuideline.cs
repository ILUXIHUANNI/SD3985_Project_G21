using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGuideline : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.enabled = false;
        }
    }
}
