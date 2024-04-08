using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestory : MonoBehaviour
{
    [SerializeField]float time = 2f;
    float timer = 0f;
    bool isDeath = false;

    Animator animator;
    float aTime = 1f;
    float aTimer = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        killing(LightDetection.instance.CheckIfCanSee(this.gameObject));
        dieAnimation(isDeath);
    }

    void killing(bool kill)
    {
        if (kill)
        {
            if (Input.GetMouseButton(1))
            {
                timer += Time.deltaTime;
            }
            if (timer > time)
            {
                isDeath = true;
                timer = 0;
            }
            if (Input.GetMouseButtonUp(1))
            {
                timer = 0;
            }
        }
    }

    void dieAnimation(bool die)
    {
        if (die)
        {
            animator.SetTrigger("Die");
            aTimer += Time.deltaTime;
            if (aTimer > aTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
