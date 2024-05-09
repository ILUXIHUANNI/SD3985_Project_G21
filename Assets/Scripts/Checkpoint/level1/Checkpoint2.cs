using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint2 : MonoBehaviour
{
    [SerializeField] GameObject plant;
    Plant plantbool;

    [SerializeField] GameObject checkObject;
    Checkpoint1 checkpoint1;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    Animator animator;

    bool isOn;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        plantbool = plant.GetComponent<Plant>();
        checkpoint1 = checkObject.GetComponent<Checkpoint1>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        checkObjectOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOn = true;
            animator.SetBool("touch", true);
            boxCollider.enabled = false;
            SaveManager.instance.Save(2, SceneManager.GetActiveScene().buildIndex);
        }
    }


    public bool getCheck()
    {
        return isOn;
    }

    void checkObjectOn()
    {
        if (checkpoint1.getCheck() && isOn == false)
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
        checkpoint1.setOn();
    }
}
