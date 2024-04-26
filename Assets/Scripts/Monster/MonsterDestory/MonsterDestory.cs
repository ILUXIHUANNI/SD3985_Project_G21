using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestory : MonoBehaviour
{
    [SerializeField]float time = 2f;
    float timer = 0f;
    bool isDeath = false;

    Animator animator;
    bool deathAnimation;

    Vector2 move;
    Vector2 lookDirection = new Vector2(1, 0);
    [SerializeField] GhostMonsterController GhostMonsterController;

    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        deathAnimation = false;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
                if (!deathAnimation)
                {
                    deathAnimation = true;
                    flip();
                    GhostMonsterController.ChangeSpeed(0.025f);
                    animator.SetTrigger("Die");
                }
            }
            if (timer > time)
            {
                isDeath = true;
                timer = 0;
                audioManager.PlaySFX(audioManager.monsterDeath);
            }
            if (Input.GetMouseButtonUp(1))
            {
                timer = 0;
                animator.SetTrigger("Die");
                GhostMonsterController.ChangeSpeed(0.05f);
                deathAnimation = false;
            }
        }
    }

    void dieAnimation(bool die)
    {
        if (die)
        {
            Destroy(this.gameObject);
        }
    }

    public bool getisDeath()
    {
        return isDeath;
    }

    void flip()
    {
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("LookX", lookDirection.x);
    }
}
