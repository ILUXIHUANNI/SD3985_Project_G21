using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    [SerializeField] GameObject checkObject;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    Plant plantbool;
    Animator animator;

    bool isOn;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        plantbool = checkObject.GetComponent<Plant>();
        animator = GetComponent<Animator>();
        loacCheckpoint();
    }

    private void Update()
    {
        checkObjectOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("touch", true);
            SaveManager.instance.Save(1, SceneManager.GetActiveScene().buildIndex);
        }
    }


    public bool getCheck()
    {
        return isOn;
    } 
    
    void checkObjectOn()
    {
        if (plantbool.getCheck()) 
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }
    
    void loacCheckpoint()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && Restart.restart && SaveManager.instance.saveFile.checkpoint == 1)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().changePostition(transform.position);
            animator.SetBool("touch", true);
        }
    }
}
