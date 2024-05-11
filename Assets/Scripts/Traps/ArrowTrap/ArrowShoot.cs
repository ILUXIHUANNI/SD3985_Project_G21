using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    AudioManager audioManager;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        DestroyArrow(LightDetection.instance.CheckIfCanSee(this.gameObject));
    }

    public void Shoot(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    /*public void Shoot(Vector2 direction,*//*float x, float y,*//* float force)
    {
        //rigidbody2d.velocity = new Vector2(x * force, y);
        rigidbody2d.AddForce(direction * force);
    }*/
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            DeathArea.isDeath = true;
        }
        //Debug.Log("Arrow Collision with " + other.gameObject);
        audioManager.PlaySFX(audioManager.arrowHit);
        Destroy(gameObject);
    }

    void DestroyArrow(bool light)
    {
        if (light && GameObject.FindGameObjectWithTag("FlashLight").GetComponent<LightController>().GetBlueModeLitghing())
        {
            audioManager.PlaySFX(audioManager.blockArrow);
            Destroy(gameObject);
        }
    }
}
