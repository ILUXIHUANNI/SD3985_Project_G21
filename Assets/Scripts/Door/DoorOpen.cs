using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    Animator animator;

    [SerializeField] GameObject plant;
    Plant plantbool;

    bool isOpen = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        plantbool = plant.GetComponent<Plant>();
    }

    private void Update()
    {
        if (plantbool.getLightOn())
            isOpen = true;
        OpenDoor(isOpen);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOpen && Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OpenDoor(bool lightOn)
    {
        if (lightOn)
        {
            animator.SetTrigger("Door Open");
        }
    }
}
