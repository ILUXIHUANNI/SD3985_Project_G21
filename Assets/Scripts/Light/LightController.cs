using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]Animator animator;
    bool isRightClick;

    private void Awake()
    {
        isRightClick = false;
    }
    private void FixedUpdate()
    {
        LightMove();
    }

    private void Update()
    {
        LightBrightness();
    }

    void LightMove()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void LightBrightness()
    {
        if (Input.GetMouseButton(1))
        {
            if (!isRightClick)
            {
                isRightClick = true;
                animator.SetBool("RightClick", true);
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            animator.SetBool("RightClick",false);
            //Debug.Log("Right Click Up");
            isRightClick = false;
        }
    }
}
