using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2Checkpoint2 : MonoBehaviour
{
    [SerializeField] GameObject plant;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    Plant plantbool;
    Animator animator;

    bool isOn;

    AudioManager audioManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        plantbool = plant.GetComponent<Plant>();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        checkObjectOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.checkpoint);
            animator.SetBool("touch", true);
            boxCollider.enabled = false;
            isOn = true;
            SaveManager.instance.Save(2, SceneManager.GetActiveScene().buildIndex);
            SaveManager.instance.SaveSimplePlant(true);
            SaveManager.instance.SaveL2Checkpoint2(true);
        }
    }


    public bool getCheck()
    {
        return isOn;
    }

    void checkObjectOn()
    {
        if (plantbool.getCheck() && isOn == false)
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }

    public void setOn()
    {
        isOn = true;
        animator.SetBool("touch", true);
        spriteRenderer.enabled = true;
        plantbool.setOn();
    }
}
