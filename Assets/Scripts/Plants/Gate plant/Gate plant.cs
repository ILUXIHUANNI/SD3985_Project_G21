using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateplant : MonoBehaviour
{
    Animator animator;

    bool lightOn = false;

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
                animator.SetBool("focus", true);
                lightOn = true;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                animator.SetBool("focus", false);
                lightOn = false;
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
