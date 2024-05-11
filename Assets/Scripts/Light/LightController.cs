using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] PlayerController playerController;
    bool isRightClick;

    float timer = 3f;
    float time;
    bool charge;
    bool isBlueModeLighting;

    AudioManager audioManager;
    private void Awake()
    {
        isRightClick = false;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
        if (playerController.GetBlueMode())
        {
            if (!charge)
            {
                if (time <= timer)
                {
                    if (Input.GetMouseButton(1))
                    {
                        if (!isRightClick)
                        {
                            isRightClick = true;
                            isBlueModeLighting = true;
                            animator.SetBool("RightClick", true);
                        }
                        time += Time.deltaTime;
                    }
                    if (Input.GetMouseButtonUp(1))
                    {
                        isBlueModeLighting = false;
                        animator.SetBool("RightClick", false);
                        //Debug.Log("Right Click Up");
                        isRightClick = false;
                    }
                    if (!isRightClick && time >= 0)
                    {
                        time -= Time.deltaTime;
                    }
                }
                else
                {
                    audioManager.PlaySFX(audioManager.powerDown);
                    isRightClick = false;
                    isBlueModeLighting = false;
                    animator.SetBool("RightClick", false);
                    charge = true;
                }
            }
            else
            {
                if (time >= 0)
                {
                    time -= Time.deltaTime;
                }
                else 
                {
                    charge = false;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                if (!isRightClick)
                {
                    isRightClick = true;
                    animator.SetBool("RightClick", true);
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                animator.SetBool("RightClick", false);
                //Debug.Log("Right Click Up");
                isRightClick = false;
            }
        }
    }

    public bool GetBlueModeLitghing()
    {
        return isBlueModeLighting;
    }
}
