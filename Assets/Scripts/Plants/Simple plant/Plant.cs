using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Animator animator;

    bool lightOn = false;

    float timer = 0f;
    float time = 2f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        focusing(LightDetection.instance.CheckIfCanSee(this.gameObject));
    }


    void focusing(bool hit)
    {
        if (hit)
        {
            if (Input.GetMouseButton(1))
            {
                timer += Time.deltaTime;
                animator.SetBool("focus", true);
            }
            if (timer > time)
            {
                lightOn = true;
            }
            else
            {
                if (Input.GetMouseButtonUp(1))
                {
                    animator.SetBool("focus", false);
                    timer = 0;
                }
            }
            
        }
    }

    public bool getCheck()
    {
        return lightOn;
    }

    public void setOn()
    {
        lightOn = true;
        animator.SetBool("focus", true);
    }
}
