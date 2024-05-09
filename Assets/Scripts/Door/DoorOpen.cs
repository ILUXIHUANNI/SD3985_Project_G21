using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    Animator animator;

    [SerializeField] GameObject plant;
    [SerializeField] int scene;
    Plant plantbool;

    [SerializeField] Animator sceneTransition;

    bool isOpen = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        plantbool = plant.GetComponent<Plant>();
    }

    private void Update()
    {
        if (plantbool.getCheck())
            isOpen = true;
        OpenDoor(isOpen);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOpen && Input.GetKey(KeyCode.E))
            {
                SaveManager.instance.Save(0, SceneManager.GetActiveScene().buildIndex);
                SaveManager.instance.SaveSimplePlant(false);
                StartCoroutine(LoadScene());
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

    IEnumerator LoadScene()
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
